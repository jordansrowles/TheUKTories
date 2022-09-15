using Newtonsoft.Json;

namespace TheUKTories.Services.Data.Selfrolled.Models
{
    public class Austeritys : BaseModel
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "string")]
        public string String { get; set; }

        [JsonProperty(PropertyName = "sources")]
        public List<SourceItem> Sources { get; set; }

        [JsonIgnore]
        public int CountSources => Sources.Count;
    }
}
