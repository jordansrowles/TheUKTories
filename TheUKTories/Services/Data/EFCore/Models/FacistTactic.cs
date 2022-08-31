namespace TheUKTories.Services.Data.EFCore.Models
{
    public class FacistTactic
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Link { get; set; }
    }
}
