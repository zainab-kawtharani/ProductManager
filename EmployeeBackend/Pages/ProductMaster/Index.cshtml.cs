using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeBackend.Model;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeBackend.ProductMaster
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EmployeeBackend.Model.DBContext _context;

        public IndexModel(EmployeeBackend.Model.DBContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Product = await _context.Products.ToListAsync();
            }
        }
    }
}
