using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Project.Data;
using E_Commerce_Project.Models;

namespace E_Commerce_Project.Areas.Admin.Pages.Inventory
{
    public class DeleteModel : PageModel
    {
        private readonly E_Commerce_Project.Data.ApplicationDbContext _context;

        public DeleteModel(E_Commerce_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ProductInventory ProductInventory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductInventory == null)
            {
                return NotFound();
            }

            var productinventory = await _context.ProductInventory.FirstOrDefaultAsync(m => m.Id == id);

            if (productinventory == null)
            {
                return NotFound();
            }
            else 
            {
                ProductInventory = productinventory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProductInventory == null)
            {
                return NotFound();
            }
            var productinventory = await _context.ProductInventory.FindAsync(id);

            if (productinventory != null)
            {
                ProductInventory = productinventory;
                _context.ProductInventory.Remove(ProductInventory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
