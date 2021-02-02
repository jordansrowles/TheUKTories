using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class SourceItem : INotifyPropertyChanged
    {
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        string _source;
        [JsonProperty(PropertyName = "source")]
        public string Source
        {
            get => _source;
            set
            {
                _source = value;
                OnPropertyChanged();
            }
        }

        string _link;
        [JsonProperty(PropertyName = "link")]
        public string Link
        {
            get => _link;
            set
            {
                _link = value;
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

        public override string ToString() => $"{Source} - {Link}";
    }
}
