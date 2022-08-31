using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages.Admin
{
    using Microsoft.AspNetCore.Authorization;
    [Authorize]
    public class DatabaseModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
