namespace TheUKTories.Services.Data.EFCore.Models
{
    public class SourceItem
    {
        public string Source { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }

        public override string ToString() => $"{Source} - {Link}";
    }
}
