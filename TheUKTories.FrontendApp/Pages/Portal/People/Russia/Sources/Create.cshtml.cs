using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Russia.Sources
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
            SelectedRusCxnId = id;
            return Page();
        }

        [BindProperty]
        public PersonRusCxnSource PersonRusCxnSource { get; set; }
        [BindProperty]
        public int SelectedRusCxnId { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            PersonRusCxnSource.PersonRusCxnId = SelectedRusCxnId;

            _context.PersonRusCxnSource.Add(PersonRusCxnSource);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
