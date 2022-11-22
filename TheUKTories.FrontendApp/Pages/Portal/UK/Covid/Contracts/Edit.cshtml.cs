using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Contracts
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
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
            GovPPEContractCompany = govppecontractcompany;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(GovPPEContractCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GovPPEContractCompanyExists(GovPPEContractCompany.GovPPEContractCompanyId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GovPPEContractCompanyExists(int id)
        {
            return (_context.CovidGovContractCompanies?.Any(e => e.GovPPEContractCompanyId == id)).GetValueOrDefault();
        }
    }
}
