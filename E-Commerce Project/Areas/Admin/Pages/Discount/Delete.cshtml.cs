using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Project.Data;
using E_Commerce_Project.Models;

namespace E_Commerce_Project.Areas.Admin.Pages.DiscountCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly E_Commerce_Project.Data.ApplicationDbContext _context;

        public DeleteModel(E_Commerce_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Discount Discount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Discount == null)
            {
                return NotFound();
            }

            var discount = await _context.Discount.FirstOrDefaultAsync(m => m.Id == id);

            if (discount == null)
            {
                return NotFound();
            }
            else
            {
                Discount = discount;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Discount == null)
            {
                return NotFound();
            }
            var discount = await _context.Discount.FindAsync(id);

            if (discount != null)
            {
                Discount = discount;
                _context.Discount.Remove(Discount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
