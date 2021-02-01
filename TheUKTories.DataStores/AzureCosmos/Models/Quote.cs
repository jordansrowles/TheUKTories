
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class Quote
    {
        [JsonProperty(PropertyName = "string")]
        public string String { get; set; }

        [JsonProperty(PropertyName = "substring")]
        public string Substring { get; set; }

        [JsonProperty(PropertyName = "sources")]
        public List<SourceItem> Sources { get; set; } = new List<SourceItem>();

        [JsonExtensionData]
        public IDictionary<string, JToken> CatchAll { get; set; }
    }
}
