using Newtonsoft.Json;
using System.Reflection;
using TheUKTories.Models;
using TheUKTories.Services.Data.Selfrolled;

namespace TheUKTories.Services.BackupService
{
    public static class DbBackupService
    {
        static readonly ICosmosContext _context;
        static string _base = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "ProgramData");

        static DbBackupService()
        {
            _context = new CosmosContext();
            // Prechecks
            Directory.CreateDirectory(_base); // create directory if it doesn't exist
        }

        public async static Task Backup()
        {
            await Backup(new List<string>() { "contacts", "covid_contracts", "covid_responses",
            "external_links", "gov_covid_contracts", "isc_report", "people", "austerity", "tactics" });
        }

        public async static Task Backup(List<string> choices)
        {
            foreach (var choice in choices)
            {
                var filename = $"{choice}.{DateTime.Now:yyyyMMddTHHmmss}.json";
                string json = choice switch
                {
                    "contacts" => await GetJsonFromCollection(new Contacts()),
                    "covid_contracts" => await GetJsonFromCollection(new CovidContracts()),
                    "covid_responses" => await GetJsonFromCollection(new CovidResponses()),
                    "external_links" => await GetJsonFromCollection(new ExternalLinks()),
                    "gov_covid_contracts" => await GetJsonFromCollection(new GovContractCompany()),
                    "isc_report" => await GetJsonFromCollection(new ISCRusReport()),
                    "people" => await GetJsonFromCollection(new Person()),
                    "austerity" => await GetJsonFromCollection(new Austeritys()),
                    _ => await GetJsonFromCollection(new ARTactics()),
                };
                Console.WriteLine($"Backing up {choice} - {filename}");
                File.WriteAllText(Path.Combine(_base, filename), json);
            }
        }

        static async Task<string> GetJsonFromCollection(object item)
        {
            return item switch
            {
                Austeritys => JsonConvert.SerializeObject(await _context.GetDocumentsAsync<Austeritys>(_context.AusterityContainer), Formatting.Indented),
                Contacts => JsonConvert.SerializeObject(await _context.GetDocumentsAsync<Contacts>(_context.ContactsContainer), Formatting.Indented),
                CovidContracts => JsonConvert.SerializeObject(await _context.GetDocumentsAsync<CovidContracts>(_context.CovidContractsContainer), Formatting.Indented),
                CovidResponses => JsonConvert.SerializeObject(await _context.GetDocumentsAsync<CovidResponses>(_context.CovidResponsesContainer), Formatting.Indented),
                ExternalLinks => JsonConvert.SerializeObject(await _context.GetDocumentsAsync<ExternalLinks>(_context.ExternalLinksContainer), Formatting.Indented),
                GovContractCompany => JsonConvert.SerializeObject(await _context.GetDocumentsAsync<GovContractCompany>(_context.GovCovidContractsContainer), Formatting.Indented),
                ISCRusReport => JsonConvert.SerializeObject(await _context.GetDocumentsAsync<ISCRusReport>(_context.ISCReportContainer), Formatting.Indented),
                Person => JsonConvert.SerializeObject(await _context.GetDocumentsAsync<Person>(_context.PeopleContainer), Formatting.Indented),
                _ => JsonConvert.SerializeObject(await _context.GetDocumentsAsync<ARTactics>(_context.TacticsContainer), Formatting.Indented),
            };
            // and i joke about Java's long-ass names lmao, im sorry
            //return retval;
        }
    }
}