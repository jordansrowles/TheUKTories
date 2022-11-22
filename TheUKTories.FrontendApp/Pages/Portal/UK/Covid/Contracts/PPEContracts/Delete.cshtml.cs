using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Contracts.PPEContracts
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CovidGovContracts == null)
            {
                return NotFound();
            }
            var govppecontract = await _context.CovidGovContracts.FindAsync(id);

            if (govppecontract != null)
            {
                GovPPEContract = govppecontract;
                _context.CovidGovContracts.Remove(GovPPEContract);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
