using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using AdonisUI.Controls;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;
using MessageBox = AdonisUI.Controls.MessageBox;
using MessageBoxButton = AdonisUI.Controls.MessageBoxButton;
using MessageBoxResult = AdonisUI.Controls.MessageBoxResult;

namespace TheUKTories.Dashboard.Reusables
{
    /// <summary>
    /// Interaction logic for GeneralPointsView.xaml
    /// </summary>
    public partial class GeneralPointsView : AdornedControl
    {
        public ObservableCollection<GeneralSubItem> GeneralItems { get; set; }

        public GeneralPointsView(List<GeneralSubItem> items)
        {
            InitializeComponent();
            GeneralItems = new ObservableCollection<GeneralSubItem>(items);
        }
    }
}
