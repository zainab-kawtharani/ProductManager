using EmployeeBackend.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeBackend.Pages
{
    public class RegisterModel : PageModel
    {   private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public Register Model { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = Model.Username,
                    Email = Model.Email

                };
                var result = await _userManager.CreateAsync(user,Model.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("ProductMaster/Index");
                }
                foreach(var error in result.Errors) {
                    ModelState.AddModelError("" , error.Description);
                }
            }

            return Page();
        }
    }
}
