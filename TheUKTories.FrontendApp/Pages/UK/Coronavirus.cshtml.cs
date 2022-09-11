using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using TheUKTories.Services.Data.Selfrolled;
using TheUKTories.Models;

namespace TheUKTories.FrontendApp.Pages.UK
{
    [AllowAnonymous]
    public class CoronavirusModel : PageModel
    {
        readonly ICosmosContext? _context;
        private readonly ILogger<CoronavirusModel>? _logger;
        public List<CovidResponses>? Responses { get; set; }
        public List<GovContractCompany>? Companies { get; set; }
        public double Total { get; set; }
        public int TotalContracts { get; set; }

        public CoronavirusModel(ILogger<CoronavirusModel> logger, ICosmosContext context)
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
