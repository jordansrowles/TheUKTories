using Newtonsoft.Json;

namespace TheUKTories.Models
{
    public class ExternalLinks : BaseModel
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
