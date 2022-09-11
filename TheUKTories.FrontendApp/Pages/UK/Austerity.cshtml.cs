using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.UK
{
    [AllowAnonymous]
    public class AusterityModel : PageModel
    {
        private readonly ILogger<AusterityModel> _logger;
        SqlServerDataContext _db;
        private readonly IConfiguration config;
        public IList<UKAusterityMeasure> AllItems = default!;
        public bool ShowAusterityDates { get; set; }

        public AusterityModel(ILogger<AusterityModel> logger, SqlServerDataContext db, IConfiguration config)
        {
            _logger = logger;
            _db = db;
            this.config = config;
            ShowAusterityDates = config.GetValue("UK.Austerity.ShowDates", false);
        }
        
        public async Task OnGetAsync(int? pageIndex)
        {
            var pagesize = config.GetValue("UK.Austerity.DefaultPageSize", 30);

            IQueryable<UKAusterityMeasure> items = from i in _db.UKAusterityMeasures select i;
            AllItems = await PaginatedList<UKAusterityMeasure>.CreateAsync(items.AsNoTracking().Include(i => i.SourceItems),
                pageIndex ?? 1, pagesize);
            AllItems.OrderByDescending(i => i.Date).ToList();
            _logger.LogInformation($"Austerty.OnGetAsync. PageIndex: {pageIndex}");
            return;
        }
    }
}
