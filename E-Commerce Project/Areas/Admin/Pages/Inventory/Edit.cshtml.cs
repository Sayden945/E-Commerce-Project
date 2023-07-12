using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Project.Data;
using E_Commerce_Project.Models;

namespace E_Commerce_Project.Areas.Admin.Pages.Inventory
{
    public class EditModel : PageModel
    {
        private readonly E_Commerce_Project.Data.ApplicationDbContext _context;

        public EditModel(E_Commerce_Project.Data.ApplicationDbContext context)
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

            var productinventory =  await _context.ProductInventory.FirstOrDefaultAsync(m => m.Id == id);
            if (productinventory == null)
            {
                return NotFound();
            }
            ProductInventory = productinventory;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductInventoryExists(ProductInventory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductInventoryExists(int id)
        {
          return (_context.ProductInventory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
