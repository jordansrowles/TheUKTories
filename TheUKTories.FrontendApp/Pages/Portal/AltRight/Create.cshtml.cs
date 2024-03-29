﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages.Portal.AltRight
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
        public FacistTactic FacistTactic { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.FacistTactics == null || FacistTactic == null)
            {
                return Page();
            }

            _context.FacistTactics.Add(FacistTactic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
