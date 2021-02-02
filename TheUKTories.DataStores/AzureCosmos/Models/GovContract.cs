using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class GovContract : INotifyPropertyChanged
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

        string _reference;
        [JsonProperty(PropertyName = "ref")]
        public string Reference
        {
            get => _reference;
            set
            {
                _reference = value;
                OnPropertyChanged();
            }
        }
    }
}
