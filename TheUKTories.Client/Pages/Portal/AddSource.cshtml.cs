using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.Client.Pages.Portal
{
    [ResponseCache(NoStore = true)]
    [Authorize]
    public class AddSourceModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
