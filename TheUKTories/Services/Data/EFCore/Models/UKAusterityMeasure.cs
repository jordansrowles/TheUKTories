using System.ComponentModel.DataAnnotations;

namespace TheUKTories.Services.Data.EFCore.Models
{
    public class UKAusterityMeasure
    {
        [Required]
        public int UKAusterityMeasureId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<UKAusterityMeasureSource> SourceItems { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
