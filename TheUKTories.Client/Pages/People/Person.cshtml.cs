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

namespace TheUKTories.Client.Pages.People
{
    [AllowAnonymous]
    public class PersonModel : PageModel
    {
        public Person Person { get; set; }
        CosmosDbContext _context;
        readonly ILogger<PersonModel> _logger;

        public string Partition { get; set; }
        public string Id { get; set; }

        public PersonModel(ILogger<PersonModel> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync([FromRoute] string partition, [FromRoute] string id)
        {
            Person = await _context.ReadItemAsync<Person>(id,
                new Microsoft.Azure.Cosmos.PartitionKey(partition),
                _context.PeopleContainer);
        }
    }
}