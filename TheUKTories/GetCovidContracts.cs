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
    public  class GetCovidContracts
    {
        readonly ICosmosDbContext _context;

        public GetCovidContracts(ICosmosDbContext context)
        {
            _context = context;
        }

        [FunctionName("GetCovidContracts")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", 
            Route = "uk/coronavirus/contracts")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var responses = await _context.GetDocumentsAsync<CovidContracts>(_context.GovCovidContractsContainer);

            return new OkObjectResult(responses);
        }
    }
}
