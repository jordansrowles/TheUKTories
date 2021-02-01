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
using System.Windows.Shapes;
using AdonisUI.Controls;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;
using MessageBox = AdonisUI.Controls.MessageBox;
using MessageBoxButton = AdonisUI.Controls.MessageBoxButton;
using MessageBoxResult = AdonisUI.Controls.MessageBoxResult;

namespace TheUKTories.Dashboard.Dialogs.AusterityWindows
{
    /// <summary>
    /// Interaction logic for AusterityWindow.xaml
    /// </summary>
    public partial class AusterityWindow : AdonisWindow
    {
        CosmosDbContext _context;
        public bool DataChanged { get; set; }
        public Austeritys Austerity { get; set; }

        public AusterityWindow(CosmosDbContext context)
        {
            InitializeComponent();
            DataChanged = false;
            _context = context;
            Austerity = new Austeritys() { Id = Guid.NewGuid().ToString() };
        }

        public AusterityWindow(CosmosDbContext context, Austeritys austerity)
        {
            InitializeComponent();
            DataChanged = false;
            _context = context;
            Austerity = austerity;

            tbString.Text = Austerity.String;
            cbType.Text = Austerity.Type;
            ctrlSources.SourceItems = Austerity.Sources;
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (Shared.ValidateListOfControls(true, tbString, cbType))
            {
                Austerity.String = tbString.Text;
                Austerity.Type = cbType.SelectedValue.ToString();
                Austerity.Sources = ctrlSources.SourceItems;

                await _context.UpsertAsync<Austeritys>(Austerity,
                    new Microsoft.Azure.Cosmos.PartitionKey(Austerity.Type),
                    _context.AusterityContainer);

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
                this.Close();
        }
    }
}
