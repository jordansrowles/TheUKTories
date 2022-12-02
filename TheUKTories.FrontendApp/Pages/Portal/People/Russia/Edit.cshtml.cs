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

namespace TheUKTories.FrontendApp.Pages.Portal.People.Russia
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonRusCxn PersonRusCxn { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PersonRusCxn == null)
            {
                return NotFound();
            }

            var personruscxn =  await _context.PersonRusCxn.FirstOrDefaultAsync(m => m.PersonRusCxnId == id);
            if (personruscxn == null)
            {
                return NotFound();
            }
            PersonRusCxn = personruscxn;
           return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(PersonRusCxn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonRusCxnExists(PersonRusCxn.PersonRusCxnId))
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

        private bool PersonRusCxnExists(int id)
        {
          return _context.PersonRusCxn.Any(e => e.PersonRusCxnId == id);
        }
    }
}
