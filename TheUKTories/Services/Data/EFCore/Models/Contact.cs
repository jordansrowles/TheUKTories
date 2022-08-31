namespace TheUKTories.Services.Data.EFCore.Models
{

    public class Contact
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }

        public override string ToString() => $"{Name} ({EmailAddress})";
    }
}
