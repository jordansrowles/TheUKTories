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
        public List<CovidResponses> CovidResponses { get; set; }

        public AllCovidResponses(CosmosDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        async Task UpdateData()
        {
            CovidResponses = await _context.GetDocumentsAsync<CovidResponses>(_context.CovidResponsesContainer);
            lvResponses.ItemsSource = CovidResponses;
        }

        private async void AdonisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await UpdateData();
        }

        private async void btnNew_Click(object sender, RoutedEventArgs e)
        {
            CovidResponseWindow window = new CovidResponseWindow(_context);
            window.ShowDialog();
            if (window.DataChanged) 
                await UpdateData();
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selected = (CovidResponses)lvResponses.SelectedItems[0];
            CovidResponseWindow window = new CovidResponseWindow(_context, selected);
            window.ShowDialog();
            if (window.DataChanged)
                await UpdateData();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult results = MessageBox.Show("Ae you sure you want to delete this item?", "Confirm deletion", MessageBoxButton.YesNo);
            if (results == MessageBoxResult.Yes)
            {
                var selected = (CovidResponses)lvResponses.SelectedItems[0];

                await _context.DeleteItemAsync<CovidResponses>(selected.Id,
                    new Microsoft.Azure.Cosmos.PartitionKey(selected.Date),
                    _context.CovidResponsesContainer);
                await UpdateData();
            }
        }

        private async void btnRefresh_Click(object sender, RoutedEventArgs e) => await UpdateData();
    }
}
