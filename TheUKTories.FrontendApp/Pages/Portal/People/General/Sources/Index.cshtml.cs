using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.People.General.Sources
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<PersonGeneralSource> PersonGeneralSource { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PersonGeneralSources != null)
            {
                PersonGeneralSource = await _context.PersonGeneralSources
                .Include(p => p.PersonGeneral).ToListAsync();
            }
        }
    }
}
