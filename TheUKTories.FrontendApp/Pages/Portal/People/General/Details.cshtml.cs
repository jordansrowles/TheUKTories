using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.People.General
{
    public class DetailsModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DetailsModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

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
    }
}
