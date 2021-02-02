using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for AllPeopleWindow.xaml
    /// </summary>
    public partial class AllPeopleWindow : AdonisWindow
    {
        CosmosDbContext _context;
        public List<Person> People { get; set; }

        public AllPeopleWindow(CosmosDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private async void AdonisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            People = await _context.GetDocumentsAsync<Person>(_context.PeopleContainer);
            dgPeople.ItemsSource = People;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            PersonWindow window = new PersonWindow((Person)dgPeople.SelectedItems[0]);
            window.ShowDialog();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
