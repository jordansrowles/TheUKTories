using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Contracts
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<GovPPEContractCompany> GovPPEContractCompany { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CovidGovContractCompanies != null)
            {
                GovPPEContractCompany = await _context.CovidGovContractCompanies.ToListAsync();
            }
        }
    }
}
