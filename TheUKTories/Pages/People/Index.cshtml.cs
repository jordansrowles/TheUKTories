using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.Pages.People
{
    public class IndexModel : PageModel
    {
        CosmosDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IList<Person> People { get; set; }

        public IndexModel(ILogger<IndexModel> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            _logger.LogInformation("Page request made: people/index");
            People = await _context.GetDocumentsAsync<Person>(_context.PeopleContainer);
        }
    }
}
