using System.ComponentModel.DataAnnotations;

namespace TheUKTories.Services.Data.EFCore.Models.Covid
{
    public class CovidGovResponseSource : SourceItem, ISourceItem
    {
        [Required]
        public int CovidGovResponseSourceId { get; set; }
        [Required]
        public int CovidGovResponseId { get; set; }
        public virtual CovidGovResponse CovidGovResponse { get; set; } = default!;
    }
}
