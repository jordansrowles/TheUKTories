using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Responses
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<CovidGovResponse> CovidGovResponse { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CovidGovResponses != null)
            {
                CovidGovResponse = await _context.CovidGovResponses
                    .Include(i => i.CovidGovResponseSources)
                    .ToListAsync();
            }
        }
    }
}
