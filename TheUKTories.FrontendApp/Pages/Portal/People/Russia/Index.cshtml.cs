﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Russia
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<PersonRusCxn> PersonRusCxn { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PersonRusCxn != null)
            {
                PersonRusCxn = await _context.PersonRusCxn
                .Include(p => p.Person).ToListAsync();
            }
        }
    }
}
