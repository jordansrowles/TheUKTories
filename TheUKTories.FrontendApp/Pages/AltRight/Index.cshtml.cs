using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.FrontendApp.Pages.AltRight
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly SqlServerDataContext _context;

        public IndexModel(SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<FacistTactic> FacistTactic { get;set; } = default!;

        public async Task OnGetAsync()
        {

            if (_context.FacistTactics != null)
            {
                FacistTactic = await _context.FacistTactics.ToListAsync();
            }
        }
    }
}
