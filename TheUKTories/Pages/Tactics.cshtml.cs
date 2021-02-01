using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.Pages
{
    public class TacticsModel : PageModel
    {
        CosmosDbContext _context;

        public IList<ARTactics> Tactics
        {
            get => _tactics;
            private set { }
        }
        readonly ILogger<TacticsModel> _logger;
        IList<ARTactics> _tactics;

        public TacticsModel(ILogger<TacticsModel> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            _tactics = await _context.GetDocumentsAsync<ARTactics>(_context.TacticsContainer);
        }
    }
}
