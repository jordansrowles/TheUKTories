using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.Covid;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Responses
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<CovidGovResponse> CovidGovResponse { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CovidGovResponses != null)
            {
                CovidGovResponse = await _context.CovidGovResponses.ToListAsync();
            }
        }
    }
}
