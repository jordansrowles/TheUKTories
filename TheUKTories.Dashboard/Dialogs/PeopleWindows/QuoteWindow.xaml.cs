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
    /// Interaction logic for QuoteWindow.xaml
    /// </summary>
    public partial class QuoteWindow : AdonisWindow
    {
        public Quote Quote { get; set; }

        public QuoteWindow(Quote quote)
        {
            InitializeComponent();
            Quote = quote;
            ctrlSources.SourceItems = quote.Sources;
            tbString.Text = quote.String;
            tbSubstring.Text = quote.Substring;
        }

        public QuoteWindow()
        {
            InitializeComponent();
            Quote = new Quote();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Quote = new Quote()
            {
                String = tbString.Text,
                Substring = tbSubstring.Text,
                Sources = ctrlSources.SourceItems
            };
            this.Tag = "DataChanged";
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
