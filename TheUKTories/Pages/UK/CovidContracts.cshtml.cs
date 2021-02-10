using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.Pages.UK
{
    public class CovidContractsModel : PageModel
    {
        public List<GovContractCompany> Companies { get; set; }
        public double Total { get; set; }
        CosmosDbContext _context;
        readonly ILogger<GovContractCompany> _logger;

        public CovidContractsModel(ILogger<GovContractCompany> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Companies = await _context.GetDocumentsAsync<GovContractCompany>(_context.GovCovidContractsContainer);
            // get total value of all contracts
            foreach (var c in Companies)
                foreach (var con in c.Contracts)
                    Total += con.Cost;
        }
    }
}
