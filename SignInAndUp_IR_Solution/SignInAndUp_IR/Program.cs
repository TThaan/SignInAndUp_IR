using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

/// <summary>
/// tasks:
/// (1) jquery to js
/// (2) "show password" option
/// (3) individualize Error page
/// (4) ta: textContent in EmailService
/// (5) move input labels into the input field??
/// btw-tasks
/// answer on SO regarding: asp.net core identity "Invalid login attempt"
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
