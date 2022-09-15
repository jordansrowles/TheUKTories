using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Quotes.Sources
{
    public class DetailsModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DetailsModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

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
    }
}
