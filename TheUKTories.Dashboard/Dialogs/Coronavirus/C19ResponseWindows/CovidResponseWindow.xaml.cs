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
    /// Interaction logic for CovidResponseWindow.xaml
    /// </summary>
    public partial class CovidResponseWindow : AdonisWindow
    {
        CosmosDbContext _context;
        public CovidResponses CovidResponse { get; set; }
        public bool DataChanged { get; set; }

        public CovidResponseWindow(CosmosDbContext context)
        {
            InitializeComponent();
            _context = context;
            CovidResponse = new CovidResponses() { Id = Guid.NewGuid().ToString() };
            DataChanged = false;
        }

        public CovidResponseWindow(CosmosDbContext context, CovidResponses response)
        {
            InitializeComponent();
            _context = context;
            CovidResponse = response;
            ctrlSources.SourceItems = response.Sources;
            DataChanged = false;

            tbString.Text = response.String;
            tbDate.Text = response.Date;
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (Shared.ValidateListOfControls(true, tbString, tbDate))
            {
                CovidResponse.String = tbString.Text;
                CovidResponse.Date = tbDate.Text;
                CovidResponse.Sources = ctrlSources.SourceItems;

                await _context.UpsertAsync<CovidResponses>(CovidResponse,
                    new Microsoft.Azure.Cosmos.PartitionKey(CovidResponse.Date),
                    _context.CovidResponsesContainer);
                DataChanged = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to cancel? All changes or potential additions could be lost.",
                "Sure?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                Close();
        }
    }
}
