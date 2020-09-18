using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignInAndUp_IR.Areas.Identity.Data;
using SignInAndUp_IR.Data;

[assembly: HostingStartup(typeof(SignInAndUp_IR.Areas.Identity.IdentityHostingStartup))]
namespace SignInAndUp_IR.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UsersDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UsersDbContextConnection")));

                // Change some default options for better developement experience.
                services.AddDefaultIdentity<User>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 3;    // doesn't work
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<UsersDbContext>();
            });
        }
    }
}