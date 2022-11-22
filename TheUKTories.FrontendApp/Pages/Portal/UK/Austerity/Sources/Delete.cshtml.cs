using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Austerity.Sources
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UKAusterityMeasureSource UKAusterityMeasureSource { get; set; } = default!;

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
            else
            {
                UKAusterityMeasureSource = ukausteritymeasuresource;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UKAusterityMeasuresSources == null)
            {
                return NotFound();
            }
            var ukausteritymeasuresource = await _context.UKAusterityMeasuresSources.FindAsync(id);

            if (ukausteritymeasuresource != null)
            {
                UKAusterityMeasureSource = ukausteritymeasuresource;
                _context.UKAusterityMeasuresSources.Remove(UKAusterityMeasureSource);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
