using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class ARTactics : BaseModel
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

        string _substring;
        [JsonProperty(PropertyName = "substring")]
        public string Substring
        {
            get => _substring;
            set
            {
                _substring = value;
                OnPropertyChanged();
            }
        }

        string _link;
        [JsonProperty(PropertyName = "wiki")]
        public string WikiLink
        {
            get => _link;
            set
            {
                _link = value;
                OnPropertyChanged();
            }
        }

    }
}
