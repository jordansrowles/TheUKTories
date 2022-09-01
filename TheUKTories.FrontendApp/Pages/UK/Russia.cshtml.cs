using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUKTories.Services.Data.Selfrolled;

namespace TheUKTories.FrontendApp.Pages.UK
{
    [AllowAnonymous]
    public class RussiaModel : PageModel
    {
        public ISCRusReport Report { get; set; }
        public List<ExternalLinks> ExternalLinks { get; set; }
        ICosmosContext _context;
        readonly ILogger<RussiaModel> _logger;

        public RussiaModel(ILogger<RussiaModel> logger, ICosmosContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task OnGetAsync()
        {
            Report = await _context.ReadItemAsync<ISCRusReport>("9f4b8d77-79e5-4ad3-b380-f6eea3ce988f",
                new Microsoft.Azure.Cosmos.PartitionKey("9f4b8d77-79e5-4ad3-b380-f6eea3ce988f"),
                _context.ISCReportContainer);

            var items = await _context.GetDocumentsAsync<ExternalLinks>(_context.ExternalLinksContainer);
            ExternalLinks = items.Where(i => i.Slug == "isc_russia_report").ToList();
        }
    }
}
