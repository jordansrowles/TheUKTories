using System;
using System.Collections.Generic;
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
using System.Linq;

namespace TheUKTories
{
    public class GetPeople
    {
        readonly ICosmosDbContext _context;

        public GetPeople(ICosmosDbContext context)
        {
            _context = context;
        }

        [FunctionName("GetPeople")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", 
            Route = "people")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var responses = await _context.GetDocumentsAsync<Person>(_context.PeopleContainer);

            return new OkObjectResult(responses);
        }
    }
}
