using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Contracts
{
    public class DetailsModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DetailsModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public GovPPEContractCompany GovPPEContractCompany { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CovidGovContractCompanies == null)
            {
                return NotFound();
            }

            var govppecontractcompany = await _context.CovidGovContractCompanies.FirstOrDefaultAsync(m => m.GovPPEContractCompanyId == id);
            if (govppecontractcompany == null)
            {
                return NotFound();
            }
            else
            {
                GovPPEContractCompany = govppecontractcompany;
            }
            return Page();
        }
    }
}
