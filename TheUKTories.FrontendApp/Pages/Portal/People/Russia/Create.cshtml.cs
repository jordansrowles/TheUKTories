using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Russia
{
    public class CreateModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public CreateModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            SelectedPersonId = id;
            return Page();
        }

        [BindProperty]
        public PersonRusCxn PersonRusCxn { get; set; }
        [BindProperty]
        public int SelectedPersonId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            PersonRusCxn.PersonId = SelectedPersonId;

            _context.PersonRusCxn.Add(PersonRusCxn);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Sources/Create", 
                new { id = PersonRusCxn.PersonRusCxnId });
        }
    }
}
