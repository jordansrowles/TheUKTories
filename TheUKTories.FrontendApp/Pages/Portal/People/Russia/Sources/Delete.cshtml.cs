using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Russia.Sources
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PersonRusCxnSource PersonRusCxnSource { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PersonRusCxnSource == null)
            {
                return NotFound();
            }

            var personruscxnsource = await _context.PersonRusCxnSource.FirstOrDefaultAsync(m => m.PersonRusCxnSourceId == id);

            if (personruscxnsource == null)
            {
                return NotFound();
            }
            else 
            {
                PersonRusCxnSource = personruscxnsource;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PersonRusCxnSource == null)
            {
                return NotFound();
            }
            var personruscxnsource = await _context.PersonRusCxnSource.FindAsync(id);

            if (personruscxnsource != null)
            {
                PersonRusCxnSource = personruscxnsource;
                _context.PersonRusCxnSource.Remove(PersonRusCxnSource);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
