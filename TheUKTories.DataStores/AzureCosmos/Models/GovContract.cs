using Newtonsoft.Json;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class GovContract
    {
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "ref")]
        public string Reference { get; set; }
    }
}
