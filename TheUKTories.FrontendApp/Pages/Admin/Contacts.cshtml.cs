using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.FrontendApp.Pages.Admin
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.EntityFrameworkCore;

    [Authorize]
    public class ContactsModel : PageModel
    {
            
        readonly CosmosEFCoreContext _context;
        private readonly ILogger<ContactsModel> _logger;
        public IEnumerable<Contact> Contacts { get; set; }

        public ContactsModel(ILogger<ContactsModel> logger, CosmosEFCoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet()
        {
            Contacts = await _context.Contacts.ToListAsync();
            _logger.LogInformation($"Accessed Admin/Contacts - {DateTime.Now}");
        }

        public async Task OnPostDeleteAllAsync()
        {
            // delete all contacts
            throw new NotImplementedException();
        }

        public async Task OnPostDeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
