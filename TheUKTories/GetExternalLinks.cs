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
    public class GetExternalLinks
    {
        readonly ICosmosDbContext _context;

        public GetExternalLinks(ICosmosDbContext context)
        {
            _context = context;
        }

        [FunctionName("GetExternalLinks")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", 
            Route = "links/{slug}")] HttpRequest req,
            string slug,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var responses = await _context.GetDocumentsAsync<ExternalLinks>(_context.ExternalLinksContainer);
            var items = responses.Where(i => i.Slug == slug).ToList();

            return new OkObjectResult(items);
        }
    }
}
