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
    public class IndexModel : PageModel
    {
        private readonly E_Commerce_Project.Data.ApplicationDbContext _context;

        public IndexModel(E_Commerce_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ProductCategory> ProductCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ProductCategory != null)
            {
                ProductCategory = await _context.ProductCategory.ToListAsync();
            }
        }
    }
}
