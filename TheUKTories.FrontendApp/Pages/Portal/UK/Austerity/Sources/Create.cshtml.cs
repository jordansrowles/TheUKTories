using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.FrontendApp.Pages.Portal.UK.Austerity.Sources
{
    public class CreateModel : PageModel
    {
        private readonly TheUKTories.Services.Data.EFCore.SqlServerDataContext _context;

        public CreateModel(TheUKTories.Services.Data.EFCore.SqlServerDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();
            
            SelectedMeasure = await _context.UKAusterityMeasures.FindAsync(id);
            if (SelectedMeasure == null) return NotFound();
            
            return Page();
        }

        [BindProperty]
        public UKAusterityMeasureSource UKAusterityMeasureSource { get; set; } = default!;
        [BindProperty]
        public UKAusterityMeasure SelectedMeasure { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            SelectedMeasure = _context.UKAusterityMeasures.Find(SelectedMeasure.UKAusterityMeasureId); // get the selected parent UKAusterityMeasure from the db context
            UKAusterityMeasureSource.UKAusterityMeasureId = SelectedMeasure.UKAusterityMeasureId; // Set the child sources parent id to the selected UKAusterityMeasure id
            UKAusterityMeasureSource.UKAusterityMeasure = SelectedMeasure; // Set the child parent object as the selected parent object
            //SelectedMeasure.SourceItems.Add(UKAusterityMeasureSource); // Add the child source to the items in selected parent
            _context.Update(SelectedMeasure); // Update the database context for parent
            _context.UKAusterityMeasuresSources.Add(UKAusterityMeasureSource); // Add the new child source to the database
            await _context.SaveChangesAsync();  // Save database changes
            return RedirectToPage("./Create", new { id = SelectedMeasure.UKAusterityMeasureId }); // Return to the list of all austerity sources
        }
    }
}
