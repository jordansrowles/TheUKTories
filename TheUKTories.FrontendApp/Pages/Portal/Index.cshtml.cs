using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages.Portal
{
    public class IndexModel : PageModel
    {
        public IndexModel(SqlServerDataContext context)
        {
            Context = context;
        }

        public SqlServerDataContext Context { get; }

        public void OnGet()
        {
        }

        public async void OnPostRecreateDatabaseAsync()
        {
            //await Context.Database.EnsureDeletedAsync();
            await Context.Database.EnsureCreatedAsync();
        }
    }
}
