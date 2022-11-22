using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Quotes
{
    public class DetailsModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DetailsModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public PersonQuote PersonQuote { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PeopleQuotes == null)
            {
                return NotFound();
            }

            var personquote = await _context.PeopleQuotes.FirstOrDefaultAsync(m => m.PersonQuoteId == id);
            if (personquote == null)
            {
                return NotFound();
            }
            else
            {
                PersonQuote = personquote;
            }
            return Page();
        }
    }
}
