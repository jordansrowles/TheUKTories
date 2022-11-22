using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.AltRight
{
    public class DetailsModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DetailsModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public FacistTactic FacistTactic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FacistTactics == null)
            {
                return NotFound();
            }

            var facisttactic = await _context.FacistTactics.FirstOrDefaultAsync(m => m.FacistTacticId == id);
            if (facisttactic == null)
            {
                return NotFound();
            }
            else
            {
                FacistTactic = facisttactic;
            }
            return Page();
        }
    }
}
