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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheUKTories.Dashboard.Reusables
{
    /// <summary>
    /// Interaction logic for DashboardTile.xaml
    /// </summary>
    public partial class DashboardTile : AdonisUI.Controls.AdornedControl
    {
        public string CountValue
        {
            get => lHeader.Content.ToString();
            set => lHeader.Content = value;
        }

        public string CountText
        {
            get => lValue.Content.ToString();
            set => lValue.Content = value;
        }

        public DashboardTile()
        {
            InitializeComponent();
        }
        public DashboardTile(string value, string text)
        {
            InitializeComponent();
            CountValue = value;
            CountText = text;
        }
    }
}
