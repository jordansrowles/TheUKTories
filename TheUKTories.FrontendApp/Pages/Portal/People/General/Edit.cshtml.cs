using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.People.General
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
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
            PersonGeneral = persongeneral;
            ViewData["PersonId"] = new SelectList(_context.People, "PersonId", "FullName");
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

            _context.Attach(PersonGeneral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonGeneralExists(PersonGeneral.PersonGeneralId))
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

        private bool PersonGeneralExists(int id)
        {
            return (_context.PeopleGeneral?.Any(e => e.PersonGeneralId == id)).GetValueOrDefault();
        }
    }
}
