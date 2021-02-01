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
    /// Interaction logic for AllAusterityWindow.xaml
    /// </summary>
    public partial class AllAusterityWindow : AdonisWindow
    {
        CosmosDbContext _context;
        List<Austeritys> AllAusteritys { get; set; }
        Austeritys SelectedAusterity { get; set; }

        public AllAusterityWindow(CosmosDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        async Task UpdateAusterities()
        {
            AllAusteritys = await _context.GetDocumentsAsync<Austeritys>(_context.AusterityContainer);
            dgAusterities.ItemsSource = AllAusteritys;
        }

        private async void AdonisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await UpdateAusterities();
            dgAusterities.ItemsSource = AllAusteritys;
        }

        private void dgAusterities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectedAusterity = (Austeritys)dgAusterities.SelectedItems[0];
                dgSources.ItemsSource = SelectedAusterity.Sources;
            }
            catch { }
        }

        private void btnLoadSources_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Austeritys selected = (Austeritys)dgAusterities.SelectedItems[0];
                dgSources.ItemsSource = selected.Sources;
            }
            catch { }

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            AusterityWindow window = new AusterityWindow(_context);
            window.ShowDialog();
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AusterityWindow window = new AusterityWindow(_context, SelectedAusterity);
                window.Show();

                if (window.DataChanged)
                    await UpdateAusterities();
            }catch { }
        }
    }
}
