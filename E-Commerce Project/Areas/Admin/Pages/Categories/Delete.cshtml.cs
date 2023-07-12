using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Project.Data;
using E_Commerce_Project.Models;

namespace E_Commerce_Project.Areas.Admin.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly E_Commerce_Project.Data.ApplicationDbContext _context;

        public DeleteModel(E_Commerce_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ProductCategory ProductCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductCategory == null)
            {
                return NotFound();
            }

            var productcategory = await _context.ProductCategory.FirstOrDefaultAsync(m => m.Id == id);

            if (productcategory == null)
            {
                return NotFound();
            }
            else 
            {
                ProductCategory = productcategory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProductCategory == null)
            {
                return NotFound();
            }
            var productcategory = await _context.ProductCategory.FindAsync(id);

            if (productcategory != null)
            {
                ProductCategory = productcategory;
                _context.ProductCategory.Remove(ProductCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
