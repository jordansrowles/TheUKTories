using Newtonsoft.Json;
using System.ComponentModel;

namespace TheUKTories.Models
{
    public class GovContractCompany : BaseModel
    {
        [JsonProperty(PropertyName = "company_name")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "people")]
        public string[] People { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("contracts")]
        public GovContract[] Contracts { get; set; }
    }
}
