using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class Austeritys : BaseModel
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "string")]
        public string String { get; set; }

        [JsonProperty(PropertyName = "sources")]
        public List<SourceItem> Sources { get; set; } = new List<SourceItem>();

        [JsonIgnore]
        public int CountSources => (Sources.Count);
    }
}
