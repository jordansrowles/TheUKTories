using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class Person : BaseModel
    {
        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "current_title")]
        public string CurrentTitle { get; set; }

        [JsonProperty(PropertyName = "other_titles")]
        public string[] OtherTitles { get; set; }

        [JsonProperty(PropertyName = "previous_titles")]
        public string[] PreviousTitles { get; set; }

        [JsonProperty(PropertyName = "profile_image")]
        public string ProfileImage { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "links")]
        public Dictionary<string, string> Links { get; set; }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        [JsonProperty(PropertyName = "general_points")]
        public List<GeneralSubItem> GeneralPoints { get; set; } = new List<GeneralSubItem>();

        [JsonProperty(PropertyName = "russian_connections")]
        public List<GeneralSubItem> RussianConnections { get; set; } = new List<GeneralSubItem>();

        [JsonProperty(PropertyName = "quotes")]
        public List<Quote> Quotes { get; set; }
    }
}
