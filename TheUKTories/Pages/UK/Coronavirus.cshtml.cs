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
    public class CoronavirusModel : PageModel
    {
        public List<CovidResponses> Responses { get; set; }

        public List<CovidContracts> Contracts { get; set; }

        CosmosDbContext _context;

        readonly ILogger<CoronavirusModel> _logger;

        public CoronavirusModel(ILogger<CoronavirusModel> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Contracts = await _context.GetDocumentsAsync<CovidContracts>(_context.CovidContractsContainer);
            Responses = await _context.GetDocumentsAsync<CovidResponses>(_context.CovidResponsesContainer);
        }
    }
}
