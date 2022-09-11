using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUKTories.Services.Data.Selfrolled;

namespace TheUKTories.FrontendApp.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        SqlServerDataContext _db;
        
        public IndexModel(ILogger<IndexModel> logger, SqlServerDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task OnGet()
        {
            //await _db.Database.EnsureDeletedAsync();
            await _db.Database.EnsureCreatedAsync();
        }
    }
}