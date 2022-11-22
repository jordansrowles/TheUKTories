using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TheUKTories.FrontendApp.Pages
{
    [AllowAnonymous]
    public class ContactModel : PageModel
    {
        [Display(Name = "Your Email Address")]
        public string? EmailAddress { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Enter your date of birth")]
        public string? Message { get; set; }

        [Display(Name = "Your Name")]
        public string? Name { get; set; }

        readonly SqlServerDataContext _context;
        private readonly ILogger<ContactModel> _logger;


        public ContactModel(ILogger<ContactModel> logger, SqlServerDataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Contact contact = new Contact()
            {
                Name = Request.Form[nameof(Name)],
                EmailAddress = Request.Form[nameof(EmailAddress)],
                Message = Request.Form[nameof(Message)],
            };

            _context.Contacts?.Add(contact);
            await _context.SaveChangesAsync();


            _logger.LogInformation($"Contact added to database {DateTime.Now}");
            return RedirectToPage("/ContactThanks");
        }
    }
}
