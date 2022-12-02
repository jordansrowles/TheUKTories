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

namespace TheUKTories.FrontendApp.Pages.Portal.People.Russia.Sources
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonRusCxnSource PersonRusCxnSource { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PersonRusCxnSource == null)
            {
                return NotFound();
            }

            var personruscxnsource =  await _context.PersonRusCxnSource.FirstOrDefaultAsync(m => m.PersonRusCxnSourceId == id);
            if (personruscxnsource == null)
            {
                return NotFound();
            }
            PersonRusCxnSource = personruscxnsource;
           ViewData["PersonRusCxnId"] = new SelectList(_context.PersonRusCxn, "PersonRusCxnId", "PersonRusCxnId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(PersonRusCxnSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonRusCxnSourceExists(PersonRusCxnSource.PersonRusCxnSourceId))
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

        private bool PersonRusCxnSourceExists(int id)
        {
          return _context.PersonRusCxnSource.Any(e => e.PersonRusCxnSourceId == id);
        }
    }
}
