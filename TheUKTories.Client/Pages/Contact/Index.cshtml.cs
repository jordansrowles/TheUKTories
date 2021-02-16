using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.Client.Pages.Contact
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public string Details { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        CosmosDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            Contacts contact = new Contacts()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Request.Form[nameof(Name)],
                EmailAddress = Request.Form[nameof(EmailAddress)],
                Details = Request.Form[nameof(Details)],
                UserAgent = Request.Headers["User-Agent"].ToString()
            };

            await _context.InsertAsync<Contacts>(contact,
                new Microsoft.Azure.Cosmos.PartitionKey(contact.UserAgent),
                _context.ContactsContainer);

            _logger.LogInformation($"Contact added to database {DateTime.Now}");
            return RedirectToPage("/Index");
        }
    }
}
