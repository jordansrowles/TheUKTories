using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People
{
    public class CreateModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public CreateModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
            /*
            if (!ModelState.IsValid || _context.People == null || Person == null)
            {
                return Page();
            }
            */
            _context.People.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
