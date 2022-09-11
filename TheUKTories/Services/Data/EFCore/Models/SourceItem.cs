namespace TheUKTories.Services.Data.EFCore.Models
{
    public class SourceItem : ISourceItem
    {
        public string Source { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
    }

    public interface ISourceItem
    {
        string Source { get; set; }
        string Link { get; set; }
        DateTime Date { get; set; }
    }
}
