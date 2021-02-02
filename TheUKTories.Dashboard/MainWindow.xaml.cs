using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AdonisUI;
using AdonisUI.Controls;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AdonisWindow
    {
        CosmosDbContext Context { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Context = new CosmosDbContext();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ResetStats();
        }

        async Task ResetStats()
        {
            tilePanel.Children.Clear();

            var aus = await Context.GetDocumentsAsync<Austeritys>(Context.AusterityContainer);
            var res = await Context.GetDocumentsAsync<CovidResponses>(Context.CovidResponsesContainer);
            var con = await Context.GetDocumentsAsync<CovidContracts>(Context.CovidContractsContainer);
            var ar = await Context.GetDocumentsAsync<ARTactics>(Context.TacticsContainer);
            var ppl = await Context.GetDocumentsAsync<Person>(Context.PeopleContainer);
            var cont = await Context.GetDocumentsAsync<Contacts>(Context.ContactsContainer);

            tilePanel.Children.Add(new Reusables.DashboardTile("Austerities", aus.Count.ToString()));
            tilePanel.Children.Add(new Reusables.DashboardTile("Covid Responses", res.Count.ToString()));
            tilePanel.Children.Add(new Reusables.DashboardTile("Covid Contracts", con.Count.ToString()));
            tilePanel.Children.Add(new Reusables.DashboardTile("Alt-Right Tactics", ar.Count.ToString()));
            tilePanel.Children.Add(new Reusables.DashboardTile("People Profiles", ppl.Count.ToString()));  
            tilePanel.Children.Add(new Reusables.DashboardTile("Contact Messages", cont.Count.ToString()));
        }

        private async void btnNewTactic_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.TacticsWindows.TacticWindow dialog = new Dialogs.TacticsWindows.TacticWindow(Context);
            dialog.ShowDialog();
            if ((string)dialog.Tag == "updated") await ResetStats();
        }

        private async void btnAllTactics_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.TacticsWindows.AllTacticsWindow dialog = new Dialogs.TacticsWindows.AllTacticsWindow(Context);
            dialog.ShowDialog();
            if ((string)dialog.Tag == "updated") await ResetStats();
        }

        private async void btnForceUpdate_Click(object sender, RoutedEventArgs e) => await ResetStats();

        private void btnManageContacts_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.Contacts.ContactsWindow dialog = new Dialogs.Contacts.ContactsWindow(Context);
            dialog.ShowDialog();
        }

        private void btnAllAusterity_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.AusterityWindows.AllAusterityWindow dialog = new Dialogs.AusterityWindows.AllAusterityWindow(Context);
            dialog.ShowDialog();
        }

        private void btnNewResponse_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void btnResponses_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.Coronavirus.C19ResponseWindows.AllCovidResponses dialog
                = new Dialogs.Coronavirus.C19ResponseWindows.AllCovidResponses(Context);
            dialog.ShowDialog();
            await ResetStats(); // todo check if changed fist
        }
    }
}
