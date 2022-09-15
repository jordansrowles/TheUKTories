namespace TheUKTories.Services.Data.EFCore.Models
{
    public class UKAusterityMeasureSource : SourceItem, ISourceItem
    {
        public int UKAusterityMeasureSourceId { get; set; }

        public int UKAusterityMeasureId { get; set; } // parent id

        public virtual UKAusterityMeasure UKAusterityMeasure { get; set; }
    }
}
