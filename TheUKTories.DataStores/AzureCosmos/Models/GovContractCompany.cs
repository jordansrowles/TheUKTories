using Newtonsoft.Json;
using System.ComponentModel;

namespace TheUKTories.DataStores.AzureCosmos.Models
{
    public class GovContractCompany : BaseModel, INotifyPropertyChanged
    {
        string _companyname;
        [JsonProperty(PropertyName = "company_name")]
        public string CompanyName
        {
            get => _companyname;
            set
            {
                _companyname = value;
                OnPropertyChanged();
            }
        }

        string[] _people;
        [JsonProperty(PropertyName = "people")]
        public string[] People
        {
            get => _people;
            set
            {
                _people = value;
                OnPropertyChanged();
            }
        }

        string _description;
        [JsonProperty("description")]
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        GovContract[] _contracts;
        [JsonProperty("contracts")]
        public GovContract[] Contracts
        {
            get => _contracts;
            set
            {
                _contracts = value;
                OnPropertyChanged();
            }
        }
    }
}
