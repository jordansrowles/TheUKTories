using Newtonsoft.Json;
using System.ComponentModel;

namespace TheUKTories.Models
{
    public class SourceItem : INotifyPropertyChanged
    {
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        //[JsonExtensionData]
        //public IDictionary<string, JToken> CatchAll { get; set; }

        public override string ToString() => $"{Source} - {Link}";
    }
}
