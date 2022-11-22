namespace TheUKTories.Services.Data.EFCore.Models.Covid
{
    public class GovPPEContractCompany
    {
        public int GovPPEContractCompanyId { get; set; }
        public string? Name { get; set; }
        public string? MainPerson { get; set; }
        public string? Description { get; set; }
        public DateTime? Founded { get; set; }

        public virtual ICollection<GovPPEContract> Contracts { get; set; } = default!;
    }
}
