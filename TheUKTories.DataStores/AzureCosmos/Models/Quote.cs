using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class Quote : INotifyPropertyChanged
    {
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

        IDictionary<string, JToken> _catchall;
        [JsonExtensionData]
        public IDictionary<string, JToken> CatchAll
        {
            get => _catchall;
            set
            {
                _catchall = value;
                OnPropertyChanged();
            }
        }
    }
}
