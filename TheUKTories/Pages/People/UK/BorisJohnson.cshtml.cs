using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.Pages.People.UK
{
    public class BorisJohnsonModel : PageModel
    {
        public Person Boris { get; set; }
        CosmosDbContext _context;
        private readonly ILogger<BorisJohnsonModel> _logger;

        public BorisJohnsonModel(ILogger<BorisJohnsonModel> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Boris = await _context.ReadItemAsync<Person>("98ed409a-c5ce-47c1-b073-01ac9997107a",
                new Microsoft.Azure.Cosmos.PartitionKey("UK"),
                _context.PeopleContainer);
        }
    }
}
