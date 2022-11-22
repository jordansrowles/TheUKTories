using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Contracts.PPEContracts
{
    public class CreateModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public CreateModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();
            GovPPEContractCompany company = await _context.CovidGovContractCompanies.FindAsync(id);
            if (company == null)
                return NotFound();
            GovPPEContractCompany = company;
            return Page();
        }

        [BindProperty]
        public GovPPEContract GovPPEContract { get; set; }
        [BindProperty]
        public GovPPEContractCompany GovPPEContractCompany { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            GovPPEContractCompany = _context.CovidGovContractCompanies.Find(GovPPEContractCompany.GovPPEContractCompanyId);
            GovPPEContract.GovPPEContractCompanyId = GovPPEContractCompany.GovPPEContractCompanyId;
            GovPPEContract.Company = GovPPEContractCompany;

            _context.CovidGovContracts.Add(GovPPEContract);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
