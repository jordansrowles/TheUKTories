using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class BaseModel : IBaseModel, INotifyPropertyChanged
    {
        // Only some models need BaseModel, things like SourceItem doesn't require an id
        string _id;
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        // Catch everything that isn't defined in the class
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

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public interface IBaseModel
    {
        string Id { get; set; }
        IDictionary<string, JToken> CatchAll { get; set; }
    }
}
