using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class CovidContracts : BaseModel
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

        List<SourceItem> _source = new List<SourceItem>();
        [JsonProperty(PropertyName = "sources")]
        public List<SourceItem> Sources
        {
            get => _source;
            set
            {
                _source = value;
                OnPropertyChanged();
            }
        }

        List<GovContract> _contacts = new List<GovContract>();
        [JsonProperty(PropertyName = "contract_links")]
        public List<GovContract> GovContracts
        {
            get => _contacts;
            set
            {
                _contacts = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        GovContract[] govContractBlank = new GovContract[] { };
    }
}
