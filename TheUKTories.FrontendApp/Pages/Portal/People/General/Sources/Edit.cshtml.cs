using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.FrontendApp.Pages.Portal.People.General.Sources
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
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

            var persongeneralsource =  await _context.PersonGeneralSources.FirstOrDefaultAsync(m => m.PersonGeneralSourceId == id);
            if (persongeneralsource == null)
            {
                return NotFound();
            }
            PersonGeneralSource = persongeneralsource;
           ViewData["PersonGeneralId"] = new SelectList(_context.PeopleGeneral, "PersonGeneralId", "PersonGeneralId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PersonGeneralSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonGeneralSourceExists(PersonGeneralSource.PersonGeneralSourceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PersonGeneralSourceExists(int id)
        {
          return (_context.PersonGeneralSources?.Any(e => e.PersonGeneralSourceId == id)).GetValueOrDefault();
        }
    }
}
