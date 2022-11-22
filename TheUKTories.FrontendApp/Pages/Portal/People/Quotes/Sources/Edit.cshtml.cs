using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Quotes.Sources
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
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
            PersonQuoteSource = personquotesource;
            ViewData["PersonQuoteId"] = new SelectList(_context.PeopleQuotes, "PersonQuoteId", "PersonQuoteId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PersonQuoteSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonQuoteSourceExists(PersonQuoteSource.PersonQuoteSourceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PersonQuoteSourceExists(int id)
        {
            return (_context.PersonQuoteSources?.Any(e => e.PersonQuoteSourceId == id)).GetValueOrDefault();
        }
    }
}
