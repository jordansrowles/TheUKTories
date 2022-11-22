using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly SqlServerDataContext _context;
        private readonly IConfiguration config;

        public IndexModel(SqlServerDataContext context, IConfiguration config)
        {
            _context = context;
            this.config = config;
        }

        public IList<Contact> Contact { get; set; } = default!;

        public async Task OnGetAsync(int? pageIndex)
        {
            IQueryable<Contact> contacts = from c in _context.Contacts select c;
            var pagesize = config.GetValue("PageSize", 15);
            Contact = await PaginatedList<Contact>.CreateAsync(contacts.AsNoTracking(),
                pageIndex ?? 1, pagesize);
        }
    }
}
