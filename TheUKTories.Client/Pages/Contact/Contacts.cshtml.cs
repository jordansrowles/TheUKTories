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

namespace TheUKTories.Client.Pages.Contact
{
    [Authorize]
    public class ContactsModel : PageModel
    {
        readonly ICosmosDbContext _context;
        private readonly ILogger<ContactsModel> _logger;
        public List<Contacts> Contacts { get; set; }

        public ContactsModel(ILogger<ContactsModel> logger, ICosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet()
        {
            Contacts = await _context.GetDocumentsAsync<Contacts>(_context.ContactsContainer);
            _logger.LogInformation($"Index.OnGet {DateTime.Now}");
        }
    }
}
