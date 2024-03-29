﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Covid.Responses
{
    public class EditModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public EditModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CovidGovResponse CovidGovResponse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CovidGovResponses == null)
            {
                return NotFound();
            }

            var covidgovresponse = await _context.CovidGovResponses.FirstOrDefaultAsync(m => m.CovidGovResponseId == id);
            if (covidgovresponse == null)
            {
                return NotFound();
            }
            CovidGovResponse = covidgovresponse;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(CovidGovResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CovidGovResponseExists(CovidGovResponse.CovidGovResponseId))
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

        private bool CovidGovResponseExists(int id)
        {
            return (_context.CovidGovResponses?.Any(e => e.CovidGovResponseId == id)).GetValueOrDefault();
        }
    }
}
