using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeBackend.Model;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeBackend.ProductMaster
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly EmployeeBackend.Model.DBContext _context;

        public CreateModel(EmployeeBackend.Model.DBContext context)
        {
            _context = context;
        }
      
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
