using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class CovidContracts : BaseModel
    {
        [JsonProperty(PropertyName = "string")]
        public string String { get; set; }

        [JsonProperty(PropertyName = "sources")]
        public List<SourceItem> Sources { get; set; } = new List<SourceItem>();

        [JsonProperty(PropertyName = "contract_links")]
        public List<GovContract> GovContracts { get; set; } = new List<GovContract>();

        [JsonIgnore]
        GovContract[] govContractBlank = new GovContract[] { };
    }
}
