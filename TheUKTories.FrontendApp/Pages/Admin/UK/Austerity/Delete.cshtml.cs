using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.FrontendApp.Pages.Admin.UK.Austerity
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.CosmosEFCoreContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.CosmosEFCoreContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UKAusterityMeasure UKAusterityMeasure { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.UKAusterityMeasures == null)
            {
                return NotFound();
            }

            var ukausteritymeasure = await _context.UKAusterityMeasures.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.UKAusterityMeasures == null)
            {
                return NotFound();
            }
            var ukausteritymeasure = await _context.UKAusterityMeasures.FindAsync(id);

            if (ukausteritymeasure != null)
            {
                UKAusterityMeasure = ukausteritymeasure;
                _context.UKAusterityMeasures.Remove(UKAusterityMeasure);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
