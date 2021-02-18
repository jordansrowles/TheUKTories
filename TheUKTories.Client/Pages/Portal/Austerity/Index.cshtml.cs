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

namespace TheUKTories.Client.Pages.Portal.Austerity
{
    [Authorize]
    public class IndexModel : PageModel
    {
        readonly ICosmosDbContext _context;
        private readonly ILogger<IndexModel> _logger;
        public Austeritys Austerity { get; set; } = new Austeritys();

        public IndexModel(ILogger<IndexModel> logger, ICosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet([FromQuery] string partition, [FromQuery] string id)
        {
            if (partition != null && id != null)
            {
                Austerity = await _context.ReadItemAsync<Austeritys>(id,
                    new Microsoft.Azure.Cosmos.PartitionKey(partition),
                    _context.AusterityContainer);
            }
            else
                Austerity.Id = Guid.NewGuid().ToString();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Austerity.String = Request.Form[nameof(Austerity.String)];
            Austerity.Type = Request.Form[nameof(Austerity.Type)];

            await _context.UpsertAsync(Austerity,
                new Microsoft.Azure.Cosmos.PartitionKey(Austerity.String),
                _context.TacticsContainer);

            _logger.LogInformation($"Contact tactic to database {DateTime.Now}");

            // todo return to add source if new item
            return RedirectToPage("/Index");
        }
    }
}
