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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AdonisUI;
using AdonisUI.Controls;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;
using MessageBox = AdonisUI.Controls.MessageBox;

namespace TheUKTories.Dashboard.Reusables
{
    /// <summary>
    /// Interaction logic for SourcesPartial.xaml
    /// </summary>
    public partial class SourcesPartial : AdornedControl
    {
        public ObservableCollection<SourceItem> _sourceItems { get; set; } = new ObservableCollection<SourceItem>();
        public List<SourceItem> SourceItems 
        {
            get => _sourceItems.ToList();
            set => _sourceItems = new ObservableCollection<SourceItem>(value);
        }

        public SourcesPartial()
        {
            InitializeComponent();
        }
        private void AdornedControl_Loaded(object sender, RoutedEventArgs e)
        {
            lvSources.ItemsSource = _sourceItems;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            if (!Shared.ValidateListOfControls(true, tbDate, tbLink, tbSource)) 
                return;
            else
            {
                _sourceItems.Add(new SourceItem()
                {
                    Source = tbSource.Text,
                    Date = tbDate.Text,
                    Link = tbLink.Text
                });
                tbSource.Text = string.Empty;
                tbDate.Text = string.Empty;
                tbLink.Text = string.Empty;
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvSources.Items.Count == 0 || (SourceItem)lvSources.SelectedItem == null)
            {
                MessageBox.Show("There are currently no sources to delete from the goup", "Error");
                return;
            }
            var selected = (SourceItem)lvSources.SelectedItem;
            try
            {
                _sourceItems.Remove(selected);
            } catch { }
        }
    }
}
