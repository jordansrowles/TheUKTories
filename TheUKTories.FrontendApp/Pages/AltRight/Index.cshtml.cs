using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
