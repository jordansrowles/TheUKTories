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
    public class NewTacticModel : PageModel
    {
        readonly ICosmosDbContext _context;
        private readonly ILogger<NewTacticModel> _logger;
        public string String { get; set; }
        public string Substring { get; set; }
        public string Link { get; set; }

        public NewTacticModel(ILogger<NewTacticModel> logger, ICosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ARTactics tactic = new ARTactics()
            {
                Id = Guid.NewGuid().ToString(),
                String = Request.Form[nameof(String)],
                Substring = Request.Form[nameof(Substring)],
                WikiLink = Request.Form[nameof(Link)]
            };

            await _context.UpsertAsync(tactic,
                new Microsoft.Azure.Cosmos.PartitionKey(tactic.String),
                _context.TacticsContainer);

            _logger.LogInformation($"Contact tactic to database {DateTime.Now}");
            return RedirectToPage("/Index");
        }
    }
}
