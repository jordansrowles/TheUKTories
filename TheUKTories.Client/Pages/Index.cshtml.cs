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

namespace TheUKTories.Client.Pages
{
    [ResponseCache(Duration = 180)]
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        readonly CosmosDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        public List<Austeritys> Austeritys { get; set; }

        public IndexModel(ILogger<IndexModel> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet()
        {
            Austeritys = await _context.GetDocumentsAsync<Austeritys>(_context.AusterityContainer);
            _logger.LogInformation($"Index.OnGet {DateTime.Now}");
        }
    }
}
