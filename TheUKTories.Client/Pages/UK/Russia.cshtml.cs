using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.Client.Pages.UK
{
    [ResponseCache(Duration = 180)]
    [AllowAnonymous]
    public class RussiaModel : PageModel
    {
        public ISCRusReport Report { get; set; }
        ICosmosDbContext _context;
        readonly ILogger<RussiaModel> _logger;

        public RussiaModel(ILogger<RussiaModel> logger, ICosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task OnGetAsync()
        {
            Report = await _context.ReadItemAsync<ISCRusReport>("9f4b8d77-79e5-4ad3-b380-f6eea3ce988f",
                new Microsoft.Azure.Cosmos.PartitionKey("9f4b8d77-79e5-4ad3-b380-f6eea3ce988f"),
                _context.ISCReportContainer);
        }
    }
}
