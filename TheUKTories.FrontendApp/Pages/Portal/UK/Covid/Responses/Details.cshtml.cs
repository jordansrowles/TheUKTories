using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Responses
{
    public class DetailsModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DetailsModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public CovidGovResponse CovidGovResponse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CovidGovResponses == null)
            {
                return NotFound();
            }

            var covidgovresponse = await _context.CovidGovResponses.Include(i => i.CovidGovResponseSources)
                .FirstOrDefaultAsync(m => m.CovidGovResponseId == id);
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
    }
}
