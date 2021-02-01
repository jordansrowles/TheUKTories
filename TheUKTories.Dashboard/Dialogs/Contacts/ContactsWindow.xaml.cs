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
using AdonisUI;
using AdonisUI.Controls;
using TheUKTories.DataStores.AzureCosmos;
using Cont = TheUKTories.DataStores.AzureCosmos.Models.Contacts;

namespace TheUKTories.Dashboard.Dialogs.Contacts
{
    /// <summary>
    /// Interaction logic for ContactsWindow.xaml
    /// </summary>
    public partial class ContactsWindow : AdonisWindow
    {
        CosmosDbContext Context { get; set; }

        public ContactsWindow(CosmosDbContext context)
        {
            Context = context;
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgContacts.ItemsSource = await Context.GetDocumentsAsync<Cont>(Context.ContactsContainer);
        }
    }
}
