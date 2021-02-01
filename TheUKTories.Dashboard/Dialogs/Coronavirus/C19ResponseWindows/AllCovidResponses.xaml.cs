using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AdonisUI.Controls;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;
using MessageBox = AdonisUI.Controls.MessageBox;
using MessageBoxButton = AdonisUI.Controls.MessageBoxButton;
using MessageBoxResult = AdonisUI.Controls.MessageBoxResult;

namespace TheUKTories.Dashboard.Dialogs.Coronavirus.C19ResponseWindows
{
    /// <summary>
    /// Interaction logic for AllCovidResponses.xaml
    /// </summary>
    public partial class AllCovidResponses : AdonisWindow
    {
        CosmosDbContext _context;
        public ObservableCollection<CovidResponses> CovidResponses { get; set; }

        public AllCovidResponses(CosmosDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private async void AdonisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var items = await _context.GetDocumentsAsync<CovidResponses>(_context.CovidResponsesContainer);
            CovidResponses = new ObservableCollection<CovidResponses>(items);
            lvResponses.ItemsSource = CovidResponses;
        }
    }
}
