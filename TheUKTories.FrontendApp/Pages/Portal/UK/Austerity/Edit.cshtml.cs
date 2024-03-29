﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Austerity
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UKAusterityMeasure UKAusterityMeasure { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UKAusterityMeasures == null)
            {
                return NotFound();
            }

            var ukausteritymeasure = await _context.UKAusterityMeasures.FirstOrDefaultAsync(m => m.UKAusterityMeasureId == id);
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

            _context.Attach(UKAusterityMeasure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UKAusterityMeasureExists(UKAusterityMeasure.UKAusterityMeasureId))
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

        private bool UKAusterityMeasureExists(int id)
        {
            return (_context.UKAusterityMeasures?.Any(e => e.UKAusterityMeasureId == id)).GetValueOrDefault();
        }
    }
}
