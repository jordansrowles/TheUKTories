using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Responses.Sources
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CovidGovResponseSource CovidGovResponseSource { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CovidGovResponseSources == null)
            {
                return NotFound();
            }

            var covidgovresponsesource = await _context.CovidGovResponseSources.FirstOrDefaultAsync(m => m.CovidGovResponseSourceId == id);

            if (covidgovresponsesource == null)
            {
                return NotFound();
            }
            else
            {
                CovidGovResponseSource = covidgovresponsesource;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CovidGovResponseSources == null)
            {
                return NotFound();
            }
            var covidgovresponsesource = await _context.CovidGovResponseSources.FindAsync(id);

            if (covidgovresponsesource != null)
            {
                CovidGovResponseSource = covidgovresponsesource;
                _context.CovidGovResponseSources.Remove(CovidGovResponseSource);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
