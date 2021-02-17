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
    [ResponseCache(Duration = 180)]
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public Person Person { get; set; }
        public List<Person> People { get; set; }
        readonly CosmosDbContext _context;
        readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            People = await _context.GetDocumentsAsync<Person>(_context.PeopleContainer);
        }
    }
}
