using AdonisUI.Controls;
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
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;
using MessageBox = AdonisUI.Controls.MessageBox;
using MessageBoxButton = AdonisUI.Controls.MessageBoxButton;
using MessageBoxResult = AdonisUI.Controls.MessageBoxResult;

namespace TheUKTories.Dashboard.Dialogs.TacticsWindows
{
    /// <summary>
    /// Interaction logic for TacticWindow.xaml
    /// </summary>
    public partial class TacticWindow : AdonisWindow
    {
        CosmosDbContext _context;
        public bool DataChanged { get; set; }

        public ARTactics Tactic { get; set; }

        public TacticWindow(CosmosDbContext context)
        {
            _context = context;
            InitializeComponent();
            DataChanged = false;
            Tactic = new ARTactics() { Id = Guid.NewGuid().ToString() };
        }

        public TacticWindow(CosmosDbContext context, ARTactics tactic)
        {
            _context = context;
            InitializeComponent();
            DataChanged = false;
            Tactic = tactic;

            tbString.Text = Tactic.String;
            tbSubstring.Text = Tactic.Substring;
            tbLink.Text = Tactic.WikiLink;
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (Shared.ValidateListOfControls(true, tbString, tbLink, tbSubstring))
            {
                DataChanged = true;
                Tactic.String = tbString.Text;
                Tactic.Substring = tbSubstring.Text;
                Tactic.WikiLink = tbLink.Text;
                await _context.UpsertAsync<ARTactics>(Tactic, 
                    new Microsoft.Azure.Cosmos.PartitionKey(Tactic.String), 
                    _context.TacticsContainer);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this item?", 
                "Delete item", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                DataChanged = false;
                this.Close();
            }
        }
    }
}
