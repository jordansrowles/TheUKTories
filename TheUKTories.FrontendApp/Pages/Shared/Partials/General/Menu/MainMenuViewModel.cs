namespace TheUKTories.FrontendApp.Pages.Shared.Partials.General.Menu
{
    public class MainMenuViewModel
    {
        public string? Title { get; set; } = "The UK Tories";
        public bool ShowSearch { get; set; } = false;

        public List<MainMenuSection> SubItems { get; set; } = default!; // for new menu
    }

    public class MainMenuSection
    {
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<MainMenuSectionLink> Links { get; set; } = default!;
    }

    public class MainMenuSectionLink
    {
        public MainMenuSectionLink(string? title, string? href, string? description)
        {
            Title = title;
            Href = href;
            Description = description;
        }

        public string? Title { get; set; }
        public string? Href { get; set; }
        public string? Description { get; set; }
    }
}
