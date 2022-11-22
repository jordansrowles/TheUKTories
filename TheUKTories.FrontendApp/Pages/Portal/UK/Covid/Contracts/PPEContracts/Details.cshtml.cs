using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Contracts.PPEContracts
{
    public class DetailsModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DetailsModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public GovPPEContract GovPPEContract { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CovidGovContracts == null)
            {
                return NotFound();
            }

            var govppecontract = await _context.CovidGovContracts.FirstOrDefaultAsync(m => m.GovPPEContractId == id);
            if (govppecontract == null)
            {
                return NotFound();
            }
            else
            {
                GovPPEContract = govppecontract;
            }
            return Page();
        }
    }
}
