using Newtonsoft.Json;

namespace TheUKTories.Models
{
    public class CovidContracts : BaseModel
    {
        [JsonProperty(PropertyName = "string")]
        public string String { get; set; }

        [JsonProperty(PropertyName = "sources")]
        public List<SourceItem> Sources { get; set; }

        [JsonProperty(PropertyName = "contract_links")]
        public List<GovContract> GovContracts { get; set; }
    }
}
