using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Quotes
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
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
            else 
            {
                PersonQuote = personquote;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PeopleQuotes == null)
            {
                return NotFound();
            }
            var personquote = await _context.PeopleQuotes.FindAsync(id);

            if (personquote != null)
            {
                PersonQuote = personquote;
                _context.PeopleQuotes.Remove(PersonQuote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
