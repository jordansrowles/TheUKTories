using Newtonsoft.Json;
using System.Collections.Generic;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class ISCRusReport : BaseModel
    {
        [JsonProperty(PropertyName = "findings")]
        public List<string> Findings { get; set; }

        [JsonProperty(PropertyName = "quotes")]
        public List<Quote> Quotes { get; set; }
    }
}
