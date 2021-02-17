using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.Client.Pages.Portal.Austerity
{
    [ResponseCache(NoStore = true)]
    [Authorize]
    public class NewAusterityModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
