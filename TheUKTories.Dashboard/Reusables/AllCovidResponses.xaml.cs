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

namespace TheUKTories.Dashboard.Dialogs.Coronavirus.C19ResponseWindows
{
    /// <summary>
    /// Interaction logic for AllCovidResponses.xaml
    /// </summary>
    public partial class Example : AdonisWindow
    {
        CosmosDbContext _context;

        public Example(CosmosDbContext context)
        {
            InitializeComponent();
            _context = context;
        }
    }
}
