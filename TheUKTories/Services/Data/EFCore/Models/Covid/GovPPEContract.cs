using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUKTories.Services.Data.EFCore.Models.Covid
{
    public class GovPPEContract
    {
        public int GovPPEContractId { get; set; }
        public virtual int GovPPEContractCompanyId { get; set; }
        public string? Source { get; set; }
        public string? Link { get; set; }
        public string? Reference { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public double Cost { get; set; }
        public DateTime? Date { get; set; }

        public virtual GovPPEContractCompany Company { get; set; } = default!;
    }
}
