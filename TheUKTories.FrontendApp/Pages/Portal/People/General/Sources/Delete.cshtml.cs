using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.General.Sources
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PersonGeneralSource PersonGeneralSource { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PersonGeneralSources == null)
            {
                return NotFound();
            }

            var persongeneralsource = await _context.PersonGeneralSources.FirstOrDefaultAsync(m => m.PersonGeneralSourceId == id);

            if (persongeneralsource == null)
            {
                return NotFound();
            }
            else 
            {
                PersonGeneralSource = persongeneralsource;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PersonGeneralSources == null)
            {
                return NotFound();
            }
            var persongeneralsource = await _context.PersonGeneralSources.FindAsync(id);

            if (persongeneralsource != null)
            {
                PersonGeneralSource = persongeneralsource;
                _context.PersonGeneralSources.Remove(PersonGeneralSource);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
