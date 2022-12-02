using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.Russia
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PersonRusCxn PersonRusCxn { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PersonRusCxn == null)
            {
                return NotFound();
            }

            var personruscxn = await _context.PersonRusCxn.FirstOrDefaultAsync(m => m.PersonRusCxnId == id);

            if (personruscxn == null)
            {
                return NotFound();
            }
            else 
            {
                PersonRusCxn = personruscxn;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PersonRusCxn == null)
            {
                return NotFound();
            }
            var personruscxn = await _context.PersonRusCxn.FindAsync(id);

            if (personruscxn != null)
            {
                PersonRusCxn = personruscxn;
                _context.PersonRusCxn.Remove(PersonRusCxn);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
