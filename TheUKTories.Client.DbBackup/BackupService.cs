using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;
using Newtonsoft.Json;

namespace TheUKTories.Client.DbBackup
{
    public static class BackupService
    {
        static readonly ICosmosDbContext _context;
        static string _base = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), 
            "ProgramData");

        static BackupService()
        {
            _context = new CosmosDbContext();
            Prechecks();
        }

        public async static void Backup(List<CheckBox> boxes)
        {
            foreach (var box in boxes)
            {
                var filename = $"{box.Tag}.{DateTime.Now:yyyyMMddTHHmmss}.json";
                string json = box.Tag switch
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
                File.WriteAllText(Path.Combine(_base, filename), json);
            }
        }

        static void Prechecks()
        {
            Directory.CreateDirectory(_base);
        }

        static async Task<string> GetJsonFromCollection(object item)
        {
            string retval = item switch
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
            return retval;
        }
    }
}
