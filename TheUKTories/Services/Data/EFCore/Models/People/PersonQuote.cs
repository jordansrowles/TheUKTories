namespace TheUKTories.Services.Data.EFCore.Models.People
{
    public class PersonQuote
    { 
        public int PersonQuoteId { get; set; }
        public virtual int PersonId { get; set; }
        public string? Quote { get; set; }
        public virtual Person? Person { get; set; }
        public virtual ICollection<PersonQuoteSource> SourceItems { get; set; } = default!;
    }
}
