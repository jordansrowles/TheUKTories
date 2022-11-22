using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Austerity.Sources
{
    public class DetailsModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DetailsModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

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
    }
}
