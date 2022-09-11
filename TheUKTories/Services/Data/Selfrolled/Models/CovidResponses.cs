using Newtonsoft.Json;

namespace TheUKTories.Models
{
    public class CovidResponses : BaseModel
    {
        [JsonProperty(PropertyName = "string")]
        public string String { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "sources")]
        public List<SourceItem> Sources { get; set; }

        public override string ToString() => String;
    }
}
