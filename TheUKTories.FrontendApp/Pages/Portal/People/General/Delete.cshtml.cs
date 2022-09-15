using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.General
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PersonGeneral PersonGeneral { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PeopleGeneral == null)
            {
                return NotFound();
            }

            var persongeneral = await _context.PeopleGeneral.FirstOrDefaultAsync(m => m.PersonGeneralId == id);

            if (persongeneral == null)
            {
                return NotFound();
            }
            else 
            {
                PersonGeneral = persongeneral;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PeopleGeneral == null)
            {
                return NotFound();
            }
            var persongeneral = await _context.PeopleGeneral.FindAsync(id);

            if (persongeneral != null)
            {
                PersonGeneral = persongeneral;
                _context.PeopleGeneral.Remove(PersonGeneral);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
