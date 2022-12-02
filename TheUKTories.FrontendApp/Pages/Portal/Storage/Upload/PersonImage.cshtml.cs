using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUKTories.Services.BlobService;

namespace TheUKTories.FrontendApp.Pages.Portal.Storage
{
    public class CreateModel : PageModel
    {
        public BlobStorageService Storage { get; set; }

        public CreateModel(BlobStorageService storage)
        {
            Storage = storage;
        }

        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {

            await Storage.UploadFileBlobAsync(file.OpenReadStream(), file.ContentType, "profiles", file.FileName);
            return RedirectToPage("../Index");
        }
    }
}
