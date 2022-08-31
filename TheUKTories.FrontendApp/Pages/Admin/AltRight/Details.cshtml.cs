using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.FrontendApp.Pages.Admin.AltRight
{
    public class DetailsModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.CosmosEFCoreContext _context;

        public DetailsModel(TheUKTories.Services.Data.EFCore.CosmosEFCoreContext context)
        {
            _context = context;
        }

      public FacistTactic FacistTactic { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.FacistTactics == null)
            {
                return NotFound();
            }

            var facisttactic = await _context.FacistTactics.FirstOrDefaultAsync(m => m.Id == id);
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
