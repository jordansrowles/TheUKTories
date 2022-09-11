using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Austerity
{
    public class DetailsModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DetailsModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

      public UKAusterityMeasure UKAusterityMeasure { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UKAusterityMeasures == null)
            {
                return NotFound();
            }

            var ukausteritymeasure = await _context.UKAusterityMeasures
                .Where(i => i.UKAusterityMeasureId == id)
                .Include(i => i.SourceItems)
                .FirstOrDefaultAsync();

            if (ukausteritymeasure == null)
            {
                return NotFound();
            }
            else 
            {
                UKAusterityMeasure = ukausteritymeasure;
            }
            return Page();
        }
    }
}
