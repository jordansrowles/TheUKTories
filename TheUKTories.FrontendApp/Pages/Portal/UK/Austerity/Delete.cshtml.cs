using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Austerity
{
    public class DeleteModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public DeleteModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UKAusterityMeasure UKAusterityMeasure { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UKAusterityMeasures == null)
            {
                return NotFound();
            }

            var ukausteritymeasure = await _context.UKAusterityMeasures.FirstOrDefaultAsync(m => m.UKAusterityMeasureId == id);

            if (ukausteritymeasure == null)
            {
                return NotFound();
            }
            else
            {
                UKAusterityMeasure = ukausteritymeasure;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UKAusterityMeasures == null)
            {
                return NotFound();
            }
            var ukausteritymeasure = await _context.UKAusterityMeasures.FindAsync(id);

            if (ukausteritymeasure != null)
            {
                UKAusterityMeasure = ukausteritymeasure;
                _context.UKAusterityMeasures.Remove(UKAusterityMeasure);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
