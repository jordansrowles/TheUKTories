namespace TheUKTories.FrontendApp.Pages.Shared.Partials.General.Menu.ServiceMenu
{
    public class ServiceMenuViewModel
    {
        public string? Title { get; set; } = "The UK Tories";
        public Dictionary<string, string> Links { get; set; } = default!;
        public string? SelectedKey { get; set; }
    }
}
