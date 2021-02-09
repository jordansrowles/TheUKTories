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

namespace TheUKTories.Dashboard.Dialogs.PeopleWindows
{
    /// <summary>
    /// Interaction logic for AllQuotesWindow.xaml
    /// </summary>
    public partial class AllQuotesWindow : AdonisWindow
    {
        public List<Quote> Quotes { get; set; }

        public AllQuotesWindow(List<Quote> quotes)
        {
            InitializeComponent();
            Quotes = quotes;

            dgQuotes.DataContext = quotes;
            ctrlSources.SourceItems = (List<SourceItem>)dgQuotes.SelectedItems[0];
        }
    }
}
