namespace TheUKTories.Services.Data.EFCore.Models
{
    public class UKAusterityMeasure
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Type { get; set; }
        public string Title { get; set; }
        public List<SourceItem> SourceItems { get; set; } = new List<SourceItem>();
        public DateTime Date { get; set; }
    }
}
