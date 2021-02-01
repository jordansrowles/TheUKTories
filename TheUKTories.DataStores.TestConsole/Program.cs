using System;
using System.Threading.Tasks;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.DataStores.TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("app starting");
            CosmosDbContext db = new CosmosDbContext();
            var data = await db.ItemFeedAsync<Austeritys>(db.AusterityContainer);

            foreach (var i in data)
            {
                Console.WriteLine(i.String);
            }
        }
    }
}
