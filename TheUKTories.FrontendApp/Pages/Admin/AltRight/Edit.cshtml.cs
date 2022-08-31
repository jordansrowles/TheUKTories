using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.FrontendApp.Pages.Admin.AltRight
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.CosmosEFCoreContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.CosmosEFCoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FacistTactic FacistTactic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.FacistTactics == null)
            {
                return NotFound();
            }

            var facisttactic =  await _context.FacistTactics.FirstOrDefaultAsync(m => m.Id == id);
            if (facisttactic == null)
            {
                return NotFound();
            }
            FacistTactic = facisttactic;
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

            _context.Attach(FacistTactic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacistTacticExists(FacistTactic.Id))
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

        private bool FacistTacticExists(string id)
        {
          return (_context.FacistTactics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
