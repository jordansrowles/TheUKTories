using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages.Admin.Austerity
{
    using Microsoft.AspNetCore.Authorization;
    [Authorize]
    public class AddSourceModel : PageModel
    {
        public string? Source { get; set; }
        public string? Link { get; set; }
        public string? Date { get; set; }

        public string? SelectedId { get; set; }
        
        public void OnGet(string id)
        {
            SelectedId = id ?? string.Empty;
            if (string.IsNullOrEmpty(SelectedId))
                RedirectToPage("/Error");
        }
    }
}
