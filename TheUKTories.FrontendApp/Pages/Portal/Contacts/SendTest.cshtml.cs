using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages.Portal.Contacts
{
    public class SendTestModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public SendTestModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Contact Contact { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Contacts?.Add(new Contact()
            {
                Message = "Test message",
                Details = "Test Details",
                EmailAddress = "test@email.co.uk",
                CreatedDate = DateTime.Now,
                Name = "John Smith"
            });
            await _context.SaveChangesAsync();

            return RedirectToPage("./SendTest");
        }
    }
}
