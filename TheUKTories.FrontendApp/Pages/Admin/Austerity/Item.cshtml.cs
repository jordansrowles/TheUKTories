using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUKTories.Services.Data.EFCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.FrontendApp.Pages.Admin.Austerity
{
    using Microsoft.AspNetCore.Authorization;
    [Authorize]
    public class ItemModel : PageModel
    {
        public string? Type { get; set; }
        public string? Content { get; set; }

        public void OnGet()
        {
            ViewData["PageHeaderMessage"] = "Add a new item";
        }
        
        public void OnGetEdit(int id)
        {
            ViewData["PageHeaderMessage"] = "Edit an existing item";
        }
        
        public void OnPostAsync()
        {
            
        }
    }
}
