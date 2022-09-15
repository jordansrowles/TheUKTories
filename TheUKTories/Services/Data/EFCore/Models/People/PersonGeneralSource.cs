namespace TheUKTories.Services.Data.EFCore.Models.People
{
    public class PersonGeneralSource : SourceItem, ISourceItem 
    {
        public int PersonGeneralSourceId { get; set; }
        public virtual int PersonGeneralId { get; set; }
        public virtual PersonGeneral PersonGeneral { get; set; } = default!;
    }
}
