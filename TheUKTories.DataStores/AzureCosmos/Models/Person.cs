using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class Person : BaseModel
    {
        string _fullname;
        [JsonProperty(PropertyName = "full_name")]
        public string FullName
        {
            get => _fullname;
            set
            {
                _fullname = value;
                OnPropertyChanged();
            }
        }

        string _title;
        [JsonProperty(PropertyName = "current_title")]
        public string CurrentTitle
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        string[] _othertitles;
        [JsonProperty(PropertyName = "other_titles")]
        public string[] OtherTitles
        {
            get => _othertitles;
            set
            {
                _othertitles = value;
                OnPropertyChanged();
            }
        }

        string[] _prevtitles;
        [JsonProperty(PropertyName = "previous_titles")]
        public string[] PreviousTitles
        {
            get => _prevtitles;
            set
            {
                _prevtitles = value;
                OnPropertyChanged();
            }
        }

        string _profileimage;
        [JsonProperty(PropertyName = "profile_image")]
        public string ProfileImage
        {
            get => _profileimage;
            set
            {
                _profileimage = value;
                OnPropertyChanged();
            }
        }

        string _country;
        [JsonProperty(PropertyName = "country")]
        public string Country
        {
            get => _country;
            set
            {
                _country = value;
                OnPropertyChanged();
            }
        }

        Dictionary<string, string> _links = new Dictionary<string, string>();
        [JsonProperty(PropertyName = "links")]
        public Dictionary<string, string> Links
        {
            get => _links;
            set
            {
                _links = value;
                OnPropertyChanged();
            }
        }

        string _slug;
        [JsonProperty(PropertyName = "slug")]
        public string Slug
        {
            get => _slug;
            set
            {
                _slug = value;
                OnPropertyChanged();
            }
        }

        List<GeneralSubItem> _general = new List<GeneralSubItem>();
        [JsonProperty(PropertyName = "general_points")]
        public List<GeneralSubItem> GeneralPoints
        {
            get => _general;
            set
            {
                _general = value;
                OnPropertyChanged();
            }
        }

        List<GeneralSubItem> _russians = new List<GeneralSubItem>();
        [JsonProperty(PropertyName = "russian_connections")]
        public List<GeneralSubItem> RussianConnections
        {
            get => _russians;
            set
            {
                _russians = value;
                OnPropertyChanged();
            }
        }

        List<Quote> _quotes = new List<Quote>();
        [JsonProperty(PropertyName = "quotes")]
        public List<Quote> Quotes
        {
            get => _quotes;
            set
            {
                _quotes = value;
                OnPropertyChanged();
            }
        }
    }
}
