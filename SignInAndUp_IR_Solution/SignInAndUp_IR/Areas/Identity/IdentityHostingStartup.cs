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

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<UsersDbContext>();
            });
        }
    }
}