using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.UK.Covid
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly SqlServerDataContext db;
        private readonly IConfiguration config;
        public IList<CovidGovResponse> AllResponses { get; set; }

        public IndexModel(ILogger<IndexModel> logger, SqlServerDataContext db, IConfiguration config)
        {
            this.logger = logger;
            this.db = db;
            this.config = config;
        }
        public async Task OnGetAsync()
        {
            AllResponses = await db.CovidGovResponses.Include(i => i.CovidGovResponseSources).ToListAsync();
        }
    }
}
