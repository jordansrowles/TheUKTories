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
    public class GetARTactics
    {
        readonly ICosmosDbContext _context;

        public GetARTactics(ICosmosDbContext context)
        {
            _context = context;
        }

        [FunctionName("GetARTactics")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", 
                Route = "misinformation")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var responses = await _context.GetDocumentsAsync<ARTactics>(_context.TacticsContainer);

            return new OkObjectResult(responses);
        }
    }
}
