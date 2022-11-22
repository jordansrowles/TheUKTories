using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.UK.Covid
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly SqlServerDataContext db;
        private readonly IConfiguration config;
        public IList<CovidGovResponse> AllResponses { get; set; }
        public IList<GovPPEContractCompany> AllContracts { get; set; }
        public double ContractsTotalCost { get; set; }


        public IndexModel(ILogger<IndexModel> logger, SqlServerDataContext db, IConfiguration config)
        {
            this.logger = logger;
            this.db = db;
            this.config = config;
        }

        public async Task OnGetAsync()
        {
            AllResponses = await db.CovidGovResponses.Include(i => i.CovidGovResponseSources).ToListAsync();
            AllContracts = await db.CovidGovContractCompanies.Include(i => i.Contracts).ToListAsync();

            try
            {
                foreach (var company in AllContracts)
                    foreach (var contract in company.Contracts)
                        ContractsTotalCost += contract.Cost;
            }
            catch (Exception ex) { }
        }
    }
}
