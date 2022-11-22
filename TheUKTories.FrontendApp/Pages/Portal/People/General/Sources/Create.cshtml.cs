using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TheUKTories.FrontendApp.Pages.Portal.People.General.Sources
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
            ViewData["PersonGeneralId"] = new SelectList(_context.PeopleGeneral, "PersonGeneralId", "PersonGeneralId");
            return Page();
        }

        [BindProperty]
        public PersonGeneralSource PersonGeneralSource { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.PersonGeneralSources == null || PersonGeneralSource == null)
            {
                return Page();
            }

            _context.PersonGeneralSources.Add(PersonGeneralSource);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
