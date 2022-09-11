using System.ComponentModel.DataAnnotations;

namespace TheUKTories.Services.Data.EFCore.Models.Covid
{
    public class CovidGovResponse
    {
        [Required]
        public int CovidGovResponseId { get; set; }
        [Required]
        public string? Title { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<CovidGovResponseSource> CovidGovResponseSources { get; set; } = default!;
    }
}
