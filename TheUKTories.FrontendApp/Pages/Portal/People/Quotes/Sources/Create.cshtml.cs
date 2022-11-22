using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Quotes.Sources
{
    public class CreateModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public CreateModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            //ViewData["PersonQuoteId"] = new SelectList(_context.PeopleQuotes, "PersonQuoteId", "PersonQuoteId");
            if (id == null) return NotFound();

            PersonQuote = await _context.PeopleQuotes.FindAsync(id);
            if (PersonQuote == null) return NotFound();
            
            return Page();
        }

        [BindProperty]
        public PersonQuote PersonQuote { get; set; } = default!;
        [BindProperty]
        public PersonQuoteSource PersonQuoteSource { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            PersonQuote = _context.PeopleQuotes.Find(PersonQuote.PersonQuoteId);
            PersonQuoteSource.PersonQuoteId = PersonQuote.PersonQuoteId;
            PersonQuoteSource.PersonQuote = PersonQuote;
            _context.Update(PersonQuote);
            _context.PersonQuoteSources.Add(PersonQuoteSource);
            await _context.SaveChangesAsync();

            return Page();
            //return RedirectToPage("./Index");
        }
    }
}
