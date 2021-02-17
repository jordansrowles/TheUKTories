using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class Contacts : BaseModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "details")]
        public string Details { get; set; }

        [JsonProperty(PropertyName = "email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "useragent")]
        public string UserAgent { get; set; }

        public override string ToString() => $"{Name} ({EmailAddress})";

    }
}