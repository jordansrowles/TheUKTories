using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.General
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<PersonGeneral> PersonGeneral { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PeopleGeneral != null)
            {
                PersonGeneral = await _context.PeopleGeneral
                .Include(p => p.Person).ToListAsync();
            }
        }
    }
}
