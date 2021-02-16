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
    public class IndexModel : PageModel
    {
        public Person Person { get; set; }
        public List<Person> People { get; set; }
        CosmosDbContext _context;
        readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync(string part, string id)
        {
            if (!string.IsNullOrEmpty(part))
                Person = await _context.ReadItemAsync<Person>(id,
                    new Microsoft.Azure.Cosmos.PartitionKey(part),
                    _context.PeopleContainer);
            else People = await _context.GetDocumentsAsync<Person>(_context.PeopleContainer);
        }
    }
}
