using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Contracts.PPEContracts
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<GovPPEContract> GovPPEContract { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CovidGovContracts != null)
            {
                GovPPEContract = await _context.CovidGovContracts
                .Include(g => g.Company).ToListAsync();
            }
        }
    }
}
