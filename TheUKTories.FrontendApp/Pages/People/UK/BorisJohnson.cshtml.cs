using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages.People.UK
{
    [AllowAnonymous]
    public class BorisJohnsonModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
