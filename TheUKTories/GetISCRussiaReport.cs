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
    public class GetISCRussiaReport
    {
        readonly ICosmosDbContext _context;

        public GetISCRussiaReport(ICosmosDbContext context)
        {
            _context = context;
        }

        [FunctionName("GetISCRussiaReport")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post",
                Route = "uk/russia/report")] HttpRequest req,
            ILogger log)

        {
            log.LogInformation("GetAusterity.Run processed a request.");

            var data = await _context.GetDocumentsAsync<ISCRusReport>(_context.ISCReportContainer);

            return new OkObjectResult(JsonConvert.SerializeObject(data));
        }
    }
}
