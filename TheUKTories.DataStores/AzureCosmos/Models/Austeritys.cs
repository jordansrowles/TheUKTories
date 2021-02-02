using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class Austeritys : BaseModel
    {
        string _type;
        [JsonProperty(PropertyName = "type")]
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        string _string;
        [JsonProperty(PropertyName = "string")]
        public string String
        {
            get => _string;
            set
            {
                _string = value;
                OnPropertyChanged();
            }
        }

        // todo needs to be initalised?
        List<SourceItem> _sources = new List<SourceItem>();
        [JsonProperty(PropertyName = "sources")]
        public List<SourceItem> Sources
        {
            get => _sources;
            set
            {
                _sources = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public int CountSources => (Sources.Count);
    }
}
