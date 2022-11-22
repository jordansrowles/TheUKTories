using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Austerity.Sources
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<UKAusterityMeasureSource> UKAusterityMeasureSource { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UKAusterityMeasuresSources != null)
            {
                UKAusterityMeasureSource = await _context.UKAusterityMeasuresSources.ToListAsync();
            }
        }
    }
}
