using Newtonsoft.Json;

namespace TheUKTories.Services.Data.Selfrolled.Models
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
