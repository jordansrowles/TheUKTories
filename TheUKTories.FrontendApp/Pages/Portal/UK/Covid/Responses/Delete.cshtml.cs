using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Responses
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CovidGovResponse CovidGovResponse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CovidGovResponses == null)
            {
                return NotFound();
            }

            var covidgovresponse = await _context.CovidGovResponses.FirstOrDefaultAsync(m => m.CovidGovResponseId == id);

            if (covidgovresponse == null)
            {
                return NotFound();
            }
            else
            {
                CovidGovResponse = covidgovresponse;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CovidGovResponses == null)
            {
                return NotFound();
            }
            var covidgovresponse = await _context.CovidGovResponses.FindAsync(id);

            if (covidgovresponse != null)
            {
                CovidGovResponse = covidgovresponse;
                _context.CovidGovResponses.Remove(CovidGovResponse);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
