using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TheUKTories.DataStores.AzureCosmos;

[assembly: FunctionsStartup(typeof(TheUKTories.Startup))]
namespace TheUKTories
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ICosmosDbContext>((c) =>
            {
                return new CosmosDbContext();
            });
        }
    }
}
