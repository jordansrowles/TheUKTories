using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.FrontendApp.Pages.Admin.Austerity
{
    public class NewModel : PageModel
    {
        CosmosEFCoreContext _context;

        public NewModel(CosmosEFCoreContext context)
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
          if (!ModelState.IsValid || _context.UKAusterityMeasures == null || UKAusterityMeasure == null)
            {
                return Page();
            }

            _context.UKAusterityMeasures.Add(UKAusterityMeasure);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
