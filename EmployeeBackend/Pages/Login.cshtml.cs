using EmployeeBackend.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeBackend.Pages
{
    public class LoginModel : PageModel
    {   
        private readonly SignInManager<IdentityUser> _signInManager;
        [BindProperty]
        public Login Model { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager=signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe,false);
                if(result.Succeeded)
                {
                   
                    return RedirectToPage("/ProductMaster/Index");
                }
                ModelState.AddModelError("", "Email or Password incorrect");

            }
            return Page();
        }
    }
}
