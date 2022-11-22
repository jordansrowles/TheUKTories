using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages.UK
{
    [AllowAnonymous]
    public class RussiaModel : PageModel
    {

        SqlServerDataContext _context;
        readonly ILogger<RussiaModel> _logger;

        public RussiaModel(ILogger<RussiaModel> logger, SqlServerDataContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task OnGetAsync()
        {

        }
    }
}
