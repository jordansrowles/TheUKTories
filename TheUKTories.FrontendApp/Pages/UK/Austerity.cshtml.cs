using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUKTories.Services.Data.Selfrolled;

namespace TheUKTories.FrontendApp.Pages.UK
{
    [AllowAnonymous]
    public class AusterityModel : PageModel
    {
        private readonly ILogger<AusterityModel> _logger;
        ICosmosContext _db;
        public List<Austeritys> AllItems = new List<Austeritys>();

        public AusterityModel(ILogger<AusterityModel> logger, ICosmosContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task OnGet()
        {
            AllItems = await _db.GetDocumentsAsync<Austeritys>(_db.AusterityContainer);
            AllItems.OrderByDescending(i => i.Id);
        }
    }
}
