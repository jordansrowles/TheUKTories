using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheUKTories.FrontendApp.Pages.People
{
    [AllowAnonymous]
    public class PersonModel : PageModel
    {
        ILogger<PersonModel>? _logger;
        ICosmosContext? _db;
        public Person Person { get; set; } = new();

        public PersonModel(ILogger<PersonModel> logger, ICosmosContext context)
        {
            _logger = logger;
            _db = context;
        }

        public async Task OnGet([FromRoute] string partition, [FromRoute] string id)
        {
            Person = await _db.GetPerson(id, partition);
        }
    }
}
