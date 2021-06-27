using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TheUKTories.DataStores;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories
{
    public class GetAusterity
    {
        readonly ICosmosDbContext _context;

        public GetAusterity(ICosmosDbContext context)
        {
            _context = context;
        }

        [FunctionName("GetAusterity")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", 
                Route = "uk/austerity")] HttpRequest req,
            ILogger log)

        {
            log.LogInformation("GetAusterity.Run processed a request.");

            var aus = await _context.GetDocumentsAsync<Austeritys>(_context.AusterityContainer);

            return new OkObjectResult(JsonConvert.SerializeObject(aus));
        }
    }
}
