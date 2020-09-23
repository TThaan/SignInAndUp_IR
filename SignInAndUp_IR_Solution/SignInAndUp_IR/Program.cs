using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

/// <summary>
/// tasks:
/// (0.1) After resetting password via 'Forgot Password' and via Google..
/// you're already logged in, even in the view saying: "Please login!".
/// (1) jquery to js
/// (2) "show password" option
/// (3) individualize Error page
/// (4) ta: textContent in EmailService
/// (5) move input labels into the input field??
/// (6) wa: delete/deactivate unused Identity routes/views?
/// btw-tasks
/// (7) Make Account views a single razor page!
/// (8) Check Identities built-in route protection/auth!
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
