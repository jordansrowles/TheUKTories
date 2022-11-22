using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages
{
    [AllowAnonymous]
    public class ContactThanksModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
