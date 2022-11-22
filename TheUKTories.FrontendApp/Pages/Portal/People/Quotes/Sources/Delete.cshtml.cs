using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Quotes.Sources
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonQuoteSource PersonQuoteSource { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PersonQuoteSources == null)
            {
                return NotFound();
            }

            var personquotesource = await _context.PersonQuoteSources.FirstOrDefaultAsync(m => m.PersonQuoteSourceId == id);

            if (personquotesource == null)
            {
                return NotFound();
            }
            else
            {
                PersonQuoteSource = personquotesource;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PersonQuoteSources == null)
            {
                return NotFound();
            }
            var personquotesource = await _context.PersonQuoteSources.FindAsync(id);

            if (personquotesource != null)
            {
                PersonQuoteSource = personquotesource;
                _context.PersonQuoteSources.Remove(PersonQuoteSource);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
