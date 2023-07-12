using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using E_Commerce_Project.Data;
using E_Commerce_Project.Models;

namespace E_Commerce_Project.Areas.Admin.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly E_Commerce_Project.Data.ApplicationDbContext _context;

        public CreateModel(E_Commerce_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductCategory ProductCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ProductCategory == null || ProductCategory == null)
            {
                return Page();
            }

            _context.ProductCategory.Add(ProductCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
