﻿using Newtonsoft.Json;
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

        [JsonProperty(PropertyName = "string")]
        public string String { get; set; }

        [JsonProperty(PropertyName = "substring")]
        public string Substring { get; set; }

        [JsonProperty(PropertyName = "sources")]
        public List<SourceItem> Sources { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> CatchAll { get; set; }
    }
}
