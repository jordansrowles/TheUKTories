namespace TheUKTories.FrontendApp.Pages.Shared.ViewModels
{
    public class MainMenuViewModel
    {
        public string? Title { get; set; } = "The UK Tories";
        public Dictionary<string, string> Links { get; set; } = default!;
        public string? SelectedKey { get; set; }
    }
}
