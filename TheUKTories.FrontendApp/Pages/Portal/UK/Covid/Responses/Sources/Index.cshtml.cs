using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Responses.Sources
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<CovidGovResponseSource> CovidGovResponseSource { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CovidGovResponseSources != null)
            {
                CovidGovResponseSource = await _context.CovidGovResponseSources
                .Include(c => c.CovidGovResponse).ToListAsync();
            }
        }
    }
}
