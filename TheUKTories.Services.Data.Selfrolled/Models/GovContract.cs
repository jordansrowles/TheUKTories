using Newtonsoft.Json;
using System.ComponentModel;

namespace TheUKTories.Services.Data.Selfrolled.Models
{
    public class GovContract : INotifyPropertyChanged
    {
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "ref")]
        public string Reference { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("cost")]
        public double Cost { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
