using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Austerity
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;
        public IList<UKAusterityMeasure> UKAusterityMeasure { get; set; }

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            if (_context.UKAusterityMeasures != null)
            {
                UKAusterityMeasure = await _context.UKAusterityMeasures.Include(i => i.SourceItems).ToListAsync();
            }
        }
    }
}
