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

namespace TheUKTories.Client.Pages.Portal.AltRight
{
    [Authorize]
    public class TacticModel : PageModel
    {
        readonly ICosmosDbContext _context;
        private readonly ILogger<TacticModel> _logger;
        public ARTactics Tactic { get; set; } = new ARTactics();

        public TacticModel(ILogger<TacticModel> logger, ICosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet([FromQuery] string partition, [FromQuery] string id)
        {
            if (partition != null && id != null)
            {
                Tactic = await _context.ReadItemAsync<ARTactics>(id,
                    new Microsoft.Azure.Cosmos.PartitionKey(partition),
                    _context.TacticsContainer);
            }
            else
                Tactic.Id = Guid.NewGuid().ToString();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Tactic.String = Request.Form[nameof(Tactic.String)];
            Tactic.Substring = Request.Form[nameof(Tactic.Substring)];
            Tactic.WikiLink = Request.Form[nameof(Tactic.WikiLink)];

            await _context.UpsertAsync(Tactic,
                new Microsoft.Azure.Cosmos.PartitionKey(Tactic.String),
                _context.TacticsContainer);

            _logger.LogInformation($"Contact tactic to database {DateTime.Now}");
            return RedirectToPage("/Index");
        }
    }
}
