using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models.Covid;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Responses.Sources
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
        ViewData["CovidGovResponseId"] = new SelectList(_context.CovidGovResponses, "CovidGovResponseId", "Title");
            return Page();
        }

        [BindProperty]
        public CovidGovResponseSource CovidGovResponseSource { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CovidGovResponseSources == null || CovidGovResponseSource == null)
            {
                return Page();
            }

            _context.CovidGovResponseSources.Add(CovidGovResponseSource);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
