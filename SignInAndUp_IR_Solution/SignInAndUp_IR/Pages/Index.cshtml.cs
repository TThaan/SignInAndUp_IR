using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SignInAndUp_IR.Areas.Identity.Data;
using System.Threading.Tasks;

namespace SignInAndUp_IR.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(UserManager<User> userManager, ILogger<IndexModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task OnGet()
        {
            //if (!User.Identity.IsAuthenticated)
            //    Response.Redirect("/Identity/Account/LogIn");

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                ViewData["FirstName"] = user.FirstName;
            }
        }
    }
}
