using Newtonsoft.Json;
using System.Collections.Generic;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class ISCRusReport : BaseModel
    {
        List<string> _findings = new List<string>();
        [JsonProperty(PropertyName = "findings")]
        public List<string> Findings
        {
            get => _findings;
            set
            {
                _findings = value;
                OnPropertyChanged();
            }
        }

        List<Quote> _quotes;
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
