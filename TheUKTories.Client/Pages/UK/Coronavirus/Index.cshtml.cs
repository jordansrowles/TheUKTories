using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.Client.Pages.UK.Coronavirus
{
    [ResponseCache(Duration = 180)]
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        readonly CosmosDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        public List<CovidResponses> Responses { get; set; }
        public List<GovContractCompany> Companies { get; set; }
        public double Total { get; set; }

        public int TotalContracts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet()
        {
            Responses = await _context.GetDocumentsAsync<CovidResponses>(_context.CovidResponsesContainer);
            Companies = await _context.GetDocumentsAsync<GovContractCompany>(_context.GovCovidContractsContainer);
            foreach (var c in Companies)
                foreach (var con in c.Contracts)
                { 
                    Total += con.Cost;
                    TotalContracts += 1;
                }
            _logger.LogInformation($"UK.Coronavirus.Index.OnGet {DateTime.Now}");
        }
    }
}
