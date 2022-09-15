using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace TheUKTories.Services.Data.Selfrolled.Models
{
    public class GeneralSubItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty(PropertyName = "string")]
        public string String { get; set; }

        [JsonProperty(PropertyName = "sources")]
        public List<SourceItem> Sources { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> CatchAll { get; set; }

    }
}
