using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Russia.Sources
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<PersonRusCxnSource> PersonRusCxnSource { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PersonRusCxnSource != null)
            {
                PersonRusCxnSource = await _context.PersonRusCxnSource
                .Include(p => p.PersonRusCxn).ToListAsync();
            }
        }
    }
}
