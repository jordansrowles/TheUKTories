using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.FrontendApp.Pages.Admin.UK.Austerity
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.CosmosEFCoreContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.CosmosEFCoreContext context)
        {
            _context = context;
        }

        public IList<UKAusterityMeasure> UKAusterityMeasure { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UKAusterityMeasures != null)
            {
                UKAusterityMeasure = await _context.UKAusterityMeasures.ToListAsync();
            }
        }
    }
}
