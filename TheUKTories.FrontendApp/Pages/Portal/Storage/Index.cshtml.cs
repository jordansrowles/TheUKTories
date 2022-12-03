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
        
        public async Task<IActionResult> OnPostUpload(IFormFile file)
        {
            await _service.UploadFileBlobAsync(file.OpenReadStream(), file.ContentType, "profiles", file.FileName);
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostDelete(string key)
        {
            if (key == null) 
                return NotFound();
            else
            {
                await _service.DeleteBlobAsync("profiles", key);
                return RedirectToPage("./Index");
            }
        }
    }
}
