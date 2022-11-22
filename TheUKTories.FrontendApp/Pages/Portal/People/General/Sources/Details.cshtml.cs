using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.People.General.Sources
{
    public class DetailsModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DetailsModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

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
    }
}
