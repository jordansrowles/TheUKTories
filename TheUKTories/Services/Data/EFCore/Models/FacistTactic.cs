using System.ComponentModel.DataAnnotations.Schema;

namespace TheUKTories.Services.Data.EFCore.Models
{
    public class FacistTactic
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int FacistTacticId { get; set; }
        public string Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Link { get; set; }
    }
}
