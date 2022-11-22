using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Austerity.Sources
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UKAusterityMeasureSource UKAusterityMeasureSource { get; set; } = default!;

        [BindProperty]
        public UKAusterityMeasure SelectedMeasure { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UKAusterityMeasuresSources == null)
            {
                return NotFound();
            }

            var ukausteritymeasuresource = await _context.UKAusterityMeasuresSources.FirstOrDefaultAsync(m => m.UKAusterityMeasureSourceId == id);
            if (ukausteritymeasuresource == null)
            {
                return NotFound();
            }
            UKAusterityMeasureSource = ukausteritymeasuresource;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UKAusterityMeasureSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UKAusterityMeasureSourceExists(UKAusterityMeasureSource.UKAusterityMeasureSourceId))
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

        private bool UKAusterityMeasureSourceExists(int id)
        {
            return (_context.UKAusterityMeasuresSources?.Any(e => e.UKAusterityMeasureSourceId == id)).GetValueOrDefault();
        }
    }
}
