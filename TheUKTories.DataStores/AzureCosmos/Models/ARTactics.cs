using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class ARTactics : BaseModel
    {
        [JsonProperty(PropertyName = "string")]
        public string String { get; set; }

        [JsonProperty(PropertyName = "substring")]
        public string Substring { get; set; }

        [JsonProperty(PropertyName = "wiki")]
        public string WikiLink { get; set; }

    }
}
