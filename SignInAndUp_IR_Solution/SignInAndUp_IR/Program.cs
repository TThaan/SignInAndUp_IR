using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


/// <summary>
/// tasks:
/// (1) jquery to js
/// (2) "show password" option
/// </summary>
namespace SignInAndUp_IR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
