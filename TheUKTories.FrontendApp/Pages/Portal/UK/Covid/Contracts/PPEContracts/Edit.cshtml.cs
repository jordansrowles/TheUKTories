using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Contracts.PPEContracts
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GovPPEContract GovPPEContract { get; set; } = default!;

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
            GovPPEContract = govppecontract;
            ViewData["GovPPEContractCompanyId"] = new SelectList(_context.CovidGovContractCompanies, "GovPPEContractCompanyId", "GovPPEContractCompanyId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(GovPPEContract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GovPPEContractExists(GovPPEContract.GovPPEContractId))
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

        private bool GovPPEContractExists(int id)
        {
            return _context.CovidGovContracts.Any(e => e.GovPPEContractId == id);
        }
    }
}
