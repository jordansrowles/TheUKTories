using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories
{
    public class GetContacts
    {
        readonly ICosmosDbContext _context;

        public GetContacts(ICosmosDbContext context)
        {
            _context = context;
        }

        [FunctionName("GetContacts")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "contacts/all")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var responses = await _context.GetDocumentsAsync<Contacts>(_context.ContactsContainer);

            return new OkObjectResult(responses);
        }
    }
}
