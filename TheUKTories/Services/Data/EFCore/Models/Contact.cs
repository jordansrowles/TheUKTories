namespace TheUKTories.Services.Data.EFCore.Models
{

    public class Contact
    {
        public int ContactId { get; set; }
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedDate { get; set; }

        public override string ToString() => $"{Name} ({EmailAddress})";
    }
}
