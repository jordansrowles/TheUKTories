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

        public void OnGet()
        {

        }
    }
}
