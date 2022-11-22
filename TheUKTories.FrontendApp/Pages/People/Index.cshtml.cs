﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.People
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.People != null)
            {
                Person = await _context.People.Where(i => i.IsProfilePublic == true).ToListAsync();
            }
        }
    }
}
