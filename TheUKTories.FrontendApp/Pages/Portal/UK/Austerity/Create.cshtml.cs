using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Austerity
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
            return Page();
        }

        [BindProperty]
        public UKAusterityMeasure UKAusterityMeasure { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _context.UKAusterityMeasures?.Add(UKAusterityMeasure);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Sources/Create", new { id = UKAusterityMeasure.UKAusterityMeasureId });
        }
    }
}
