using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUKTories.Services.BlobService;

namespace TheUKTories.FrontendApp.Pages.Portal.Storage
{
    public class IndexModel : PageModel
    {
        BlobStorageService _service;
        [BindProperty]
        public Dictionary<string, Uri> ProfileImages { get; set; } = new();


        public IndexModel(BlobStorageService service)
        {
            _service = service;
        }

        public async Task OnGet()
        {
            ProfileImages = await _service.Iterate("profiles");
        }
    }
}
