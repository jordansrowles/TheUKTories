using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Quotes.Sources
{
    public class CreateModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public CreateModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PersonQuoteId"] = new SelectList(_context.PeopleQuotes, "PersonQuoteId", "PersonQuoteId");
            return Page();
        }

        [BindProperty]
        public PersonQuoteSource PersonQuoteSource { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.PersonQuoteSources == null || PersonQuoteSource == null)
            {
                return Page();
            }

            _context.PersonQuoteSources.Add(PersonQuoteSource);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
