using System;
using System.Collections.Generic;
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

namespace TheUKTories.Dashboard.Dialogs.TacticsWindows
{
    /// <summary>
    /// Interaction logic for AllTacticsWindow.xaml
    /// </summary>
    public partial class AllTacticsWindow : AdonisWindow
    {
        CosmosDbContext _context;

        public List<ARTactics> AllTactics { get; set; }

        public ARTactics SelectedTactic { get; set; }

        public AllTacticsWindow(CosmosDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        async Task UpdateData()
        {
            AllTactics = await _context.GetDocumentsAsync<ARTactics>(_context.TacticsContainer);
            dgData.ItemsSource = AllTactics;
        }

        private async void btnRefresh_Click(object sender, RoutedEventArgs e) => await UpdateData();
        private async void AdonisWindow_Loaded(object sender, RoutedEventArgs e) => await UpdateData();

        private void btnWiki_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnNew_Click(object sender, RoutedEventArgs e)
        {
            TacticWindow window = new TacticWindow(_context);
            window.ShowDialog();

            if (window.DataChanged) await UpdateData();
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (ARTactics)dgData.SelectedItems[0];
            TacticWindow window = new TacticWindow(_context, item);
            window.ShowDialog();

            if (window.DataChanged) await UpdateData();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult results = MessageBox.Show("Ae you sure you want to delete this item?", "Confirm deletion",
                MessageBoxButton.YesNo);
            if (results == MessageBoxResult.Yes)
            {
                var selected = (ARTactics)dgData.SelectedItems[0];

                await _context.DeleteItemAsync<ARTactics>(selected.Id,
                    new Microsoft.Azure.Cosmos.PartitionKey(selected.String),
                    _context.TacticsContainer);
                await UpdateData();
            }

        }
    }
}
