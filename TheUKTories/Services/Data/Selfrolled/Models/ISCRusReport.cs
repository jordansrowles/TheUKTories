using Newtonsoft.Json;

namespace TheUKTories.Models
{
    public class ISCRusReport : BaseModel
    {
        [JsonProperty(PropertyName = "findings")]
        public List<string> Findings { get; set; }

        [JsonProperty(PropertyName = "quotes")]
        public List<Quote> Quotes { get; set; }
    }
}
