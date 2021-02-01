using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class SourceItem
    {
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> CatchAll { get; set; }

        public override string ToString() => $"{Source} - {Link}";
    }
}
