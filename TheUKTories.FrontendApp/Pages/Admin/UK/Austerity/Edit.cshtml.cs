using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.FrontendApp.Pages.Admin.UK.Austerity
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.CosmosEFCoreContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.CosmosEFCoreContext context)
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

            var ukausteritymeasure =  await _context.UKAusterityMeasures.FirstOrDefaultAsync(m => m.Id == id);
            if (ukausteritymeasure == null)
            {
                return NotFound();
            }
            UKAusterityMeasure = ukausteritymeasure;
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

            _context.Attach(UKAusterityMeasure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UKAusterityMeasureExists(UKAusterityMeasure.Id))
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

        private bool UKAusterityMeasureExists(string id)
        {
          return (_context.UKAusterityMeasures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
