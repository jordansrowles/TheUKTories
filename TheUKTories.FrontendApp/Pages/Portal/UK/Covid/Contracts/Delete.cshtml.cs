using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Contracts
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CovidGovContractCompanies == null)
            {
                return NotFound();
            }
            var govppecontractcompany = await _context.CovidGovContractCompanies.FindAsync(id);

            if (govppecontractcompany != null)
            {
                GovPPEContractCompany = govppecontractcompany;
                _context.CovidGovContractCompanies.Remove(GovPPEContractCompany);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
