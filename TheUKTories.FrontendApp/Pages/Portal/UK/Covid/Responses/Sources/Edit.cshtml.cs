using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Responses.Sources
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CovidGovResponseSource CovidGovResponseSource { get; set; } = default!;
        [BindProperty]
        public CovidGovResponse CovidGovResponse { get; set; } = default!;

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
            CovidGovResponseSource = covidgovresponsesource;
            ViewData["CovidGovResponseId"] = new SelectList(_context.CovidGovResponses, "CovidGovResponseId", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CovidGovResponseSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CovidGovResponseSourceExists(CovidGovResponseSource.CovidGovResponseSourceId))
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

        private bool CovidGovResponseSourceExists(int id)
        {
            return (_context.CovidGovResponseSources?.Any(e => e.CovidGovResponseSourceId == id)).GetValueOrDefault();
        }
    }
}
