using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal
{
    public class DbReportModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DbReportModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public int? TacticCount { get; set; } = 0;
        public int? ContactCount { get; set; } = 0;
        public int? AusterityCount { get; set; } = 0;
        public int? AusterityCountSourceless { get; set; } = 0;
        public int? AusteritySourcesCount { get; set; } = 0;

        public int? CovidResponseCount { get; set; }

        public int? CovidCompanyNoContracts { get; set; } = 0;

        public async Task OnGetAsync()
        {
            TacticCount = await _context.FacistTactics.CountAsync();
            ContactCount = await _context.Contacts.CountAsync();
            AusterityCount = await _context.UKAusterityMeasures.CountAsync();
            AusterityCountSourceless = await _context.UKAusterityMeasures.
                Include(i => i.SourceItems).
                Where(i => i.SourceItems.Count == 0).CountAsync();
            AusteritySourcesCount = await _context.UKAusterityMeasuresSources.CountAsync();
            CovidCompanyNoContracts = await _context.CovidGovContractCompanies.Include(i => i.Contracts)
                .Where(i => i.Contracts.Count() == 0).CountAsync();
            CovidResponseCount = await _context.CovidGovResponses.CountAsync();

        }
    }
}
