using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.AltRight
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FacistTactics == null)
            {
                return NotFound();
            }
            var facisttactic = await _context.FacistTactics.FindAsync(id);

            if (facisttactic != null)
            {
                FacistTactic = facisttactic;
                _context.FacistTactics.Remove(FacistTactic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
