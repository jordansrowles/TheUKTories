using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class BaseModel : IBaseModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> CatchAll { get; set; }
    }

    public interface IBaseModel
    {
        string Id { get; set; }
        IDictionary<string, JToken> CatchAll { get; set; }
    }
}
