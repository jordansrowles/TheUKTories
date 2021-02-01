using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.Pages
{
    public class ContactSentModel : PageModel
    {
        [BindProperty]
        public string Details { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string EmailAddress { get; set; }

        public void OnGet(string details, string name, string email)
        {
            EmailAddress = email;
            Name = name;
            Details = details;
        }
    }
}
