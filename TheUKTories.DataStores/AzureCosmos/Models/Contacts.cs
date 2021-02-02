using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class Contacts : BaseModel
    {
        string _name;
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        string _details;
        [JsonProperty(PropertyName = "details")]
        public string Details
        {
            get => _details;
            set
            {
                _details = value;
                OnPropertyChanged();
            }
        }

        string _emailaddress;
        [JsonProperty(PropertyName = "email_address")]
        public string EmailAddress
        {
            get => _emailaddress;
            set
            {
                _emailaddress = value;
                OnPropertyChanged();
            }
        }

        string _useragent;
        [JsonProperty(PropertyName = "useragent")]
        public string UserAgent
        {
            get => _useragent;
            set
            {
                _useragent = value;
                OnPropertyChanged();
            }
        }

        public override string ToString() => $"{Name} ({EmailAddress})";

    }
}