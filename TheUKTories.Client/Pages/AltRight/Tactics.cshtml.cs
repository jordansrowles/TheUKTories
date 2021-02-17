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

namespace TheUKTories.Client.Pages.AltRight
{
    [ResponseCache(Duration = 180)]
    [AllowAnonymous]
    public class TacticsModel : PageModel
    {
        public List<ARTactics> Tactics { get; set; }
        CosmosDbContext _context;
        readonly ILogger<TacticsModel> _logger;

        public TacticsModel(ILogger<TacticsModel> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task OnGetAsync()
        {
            Tactics = await _context.GetDocumentsAsync<ARTactics>(_context.TacticsContainer);
        }
    }
}
