using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class CovidResponses : BaseModel
    {
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

        string _date;
        [JsonProperty(PropertyName = "date")]
        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

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

        public override string ToString() => String;
    }
}
