namespace TheUKTories.Services.Data.EFCore.Models.People
{
    public class PersonQuoteSource : SourceItem, ISourceItem 
    {
        public int PersonQuoteSourceId { get; set; }
        public virtual int PersonQuoteId { get; set; }
        public virtual PersonQuote PersonQuote { get; set; } = default!;
    }
}
