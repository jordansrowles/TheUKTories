using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Quotes.Sources
{
    public class IndexModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public IndexModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IList<PersonQuoteSource> PersonQuoteSource { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PersonQuoteSources != null)
            {
                PersonQuoteSource = await _context.PersonQuoteSources
                .Include(p => p.PersonQuote).ToListAsync();
            }
        }
    }
}
