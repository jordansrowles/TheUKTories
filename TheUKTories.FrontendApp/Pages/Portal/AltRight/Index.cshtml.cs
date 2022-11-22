using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.AltRight
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<FacistTactic> FacistTactic { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FacistTactics != null)
            {
                FacistTactic = await _context.FacistTactics.ToListAsync();
            }
        }
    }
}
