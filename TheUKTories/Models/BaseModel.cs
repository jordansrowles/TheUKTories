using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheUKTories.Models
{
    public class BaseModel : IBaseModel, INotifyPropertyChanged
    {
        // Only some models need BaseModel, things like SourceItem doesn't require an id
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }


        // Catch everything that isn't defined in the class
        //[JsonExtensionData]
        //public IDictionary<string, JToken> CatchAll { get; set; }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public interface IBaseModel
    {
        string Id { get; set; }
        //IDictionary<string, JToken> CatchAll { get; set; }
    }
}
