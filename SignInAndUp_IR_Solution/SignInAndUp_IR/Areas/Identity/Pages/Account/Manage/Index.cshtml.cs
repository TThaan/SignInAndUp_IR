using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignInAndUp_IR.Areas.Identity.Data;

namespace SignInAndUp_IR.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [PersonalData]
            [Column(TypeName = "nvarchar(50)")]
            [Display(Name = "Alias")]
            public string Alias { get; set; }

            [Required]
            [PersonalData]
            [Column(TypeName = "nvarchar(50)")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [PersonalData]
            [Column(TypeName = "nvarchar(50)")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var alias = await _userManager.GetUserNameAsync(user);


            Alias = alias;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Input.Alias != user.UserName ||
                Input.FirstName != user.FirstName ||
                Input.LastName != user.LastName)
            {
                user.UserName = Input.Alias;
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;

                var updateResult = await _userManager.UpdateAsync(user);
                
                if (!updateResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to update the user data.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}