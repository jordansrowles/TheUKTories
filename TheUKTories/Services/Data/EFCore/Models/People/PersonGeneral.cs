namespace TheUKTories.Services.Data.EFCore.Models.People
{
    public class PersonGeneral
    {
        public int PersonGeneralId { get; set; }
        public virtual int PersonId { get; set; }
        public string? Category { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public virtual Person? Person { get; set; }
        public ICollection<PersonGeneralSource> SourceItems { get; set; } = default!;
    }
}
