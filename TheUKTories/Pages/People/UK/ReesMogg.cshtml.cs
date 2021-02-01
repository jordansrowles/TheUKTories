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
    public class ReesMoggModel : PageModel
    {
        public Person Jacob { get; set; }
        CosmosDbContext _context;
        private readonly ILogger<ReesMoggModel> _logger;

        public ReesMoggModel(ILogger<ReesMoggModel> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Jacob = await _context.ReadItemAsync<Person>("214710d1-3772-4be3-a2cd-99cdcf356386", 
                new Microsoft.Azure.Cosmos.PartitionKey("UK"),
                _context.PeopleContainer);
        }
    }
}
