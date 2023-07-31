using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Project.Data;
using E_Commerce_Project.Models;

namespace E_Commerce_Project.Areas.Cart.Pages
{
    public class CheckoutModel : PageModel
    {

        public void OnGet() { }

        private readonly E_Commerce_Project.Data.ApplicationDbContext _context;

        public CheckoutModel(E_Commerce_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ShoppingSession ShoppingSession { get; set; } = default!;

        /*
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ShoppingSession == null)
            {
                return NotFound();
            }

            var shoppingsession = await _context.ShoppingSession.FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingsession == null)
            {
                return NotFound();
            }
            else
            {
                ShoppingSession = shoppingsession;
            }
            return Page();
        }
        */
    }
}
