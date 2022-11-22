using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Quotes
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
            if (id == null) return NotFound();
            Person = await _context.People.FindAsync(id);
            if (Person == null) return NotFound();
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; } = default!;
        [BindProperty]
        public PersonQuote PersonQuote { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Person = _context.People.Find(Person.PersonId);
            PersonQuote.PersonId = Person.PersonId;
            PersonQuote.Person = Person;
            _context.Update(Person);
            _context.PeopleQuotes.Add(PersonQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Sources/Create", new { id = PersonQuote.PersonQuoteId });
        }
    }
}
