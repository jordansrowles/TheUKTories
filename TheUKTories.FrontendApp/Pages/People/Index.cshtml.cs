using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUKTories.Services.Data.Selfrolled;

namespace TheUKTories.FrontendApp.Pages.People
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        ILogger<IndexModel>? _logger;
        ICosmosContext _db;
        public List<Person> People { get; set; } = new();

        public IndexModel(ILogger<IndexModel> logger, ICosmosContext context)
        {
            _db = context;
        }

        public async Task OnGetAsync()
        {
            People = await _db.GetDocumentsAsync<Person>(_db.PeopleContainer);
        }
    }
}
