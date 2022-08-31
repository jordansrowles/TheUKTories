using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        ICosmosContext _db;
        
        public IndexModel(ILogger<IndexModel> logger, ICosmosContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task OnGet()
        {
        }
    }
}