using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Quotes
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            PersonQuote = personquote;
            ViewData["PersonId"] = new SelectList(_context.People, "PersonId", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(PersonQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonQuoteExists(PersonQuote.PersonQuoteId))
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

        private bool PersonQuoteExists(int id)
        {
            return (_context.PeopleQuotes?.Any(e => e.PersonQuoteId == id)).GetValueOrDefault();
        }
    }
}
