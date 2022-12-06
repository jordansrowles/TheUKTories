using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages
{
    [AllowAnonymous]
    [ResponseCache(NoStore = true)]
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
            //_db.Database.Migrate();
        }
    }
}