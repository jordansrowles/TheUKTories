﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<PersonQuote> PersonQuote { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PeopleQuotes != null)
            {
                PersonQuote = await _context.PeopleQuotes
                .Include(p => p.Person).ToListAsync();
            }
        }
    }
}
