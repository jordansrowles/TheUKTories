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
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : AdonisWindow
    {
        public Person Person { get; set; }

        public PersonWindow(Person person)
        {
            InitializeComponent();
            Person = person;
            this.DataContext = Person;
            Unpack();
        }

        // load all of the person data into the controls
        void Unpack()
        {
            tbCountry.Text = Person.Country;
            tbName.Text = Person.FullName;
            tbSlug.Text = Person.Slug;
            tbTitle.Text = Person.CurrentTitle;
            tbImgPath.Text = Person.ProfileImage;

            // populate listviews
            if (Person.OtherTitles != null)
                Array.ForEach(Person.OtherTitles, i => lbOtherTitles.Items.Add(i));
            if (Person.PreviousTitles != null)
                Array.ForEach(Person.PreviousTitles, p => lbPrevTitles.Items.Add(p));

            Resources["PersonLinks"] = Person.Links; // used for binding
            dgQuotes.ItemsSource = Person.Quotes;

            imgProfile.Source = new BitmapImage(new Uri(Person.ProfileImage)); // set profile image
        }

        // packup all the data and return the object
        Person Pack() => new Person()
        {
            Country = tbCountry.Text,
            FullName = tbName.Text,
            Slug = tbSlug.Text,
            CurrentTitle = tbTitle.Text,
            ProfileImage = tbImgPath.Text,
            // the complex
            OtherTitles = lbOtherTitles.Items.OfType<string>().ToArray(),
            PreviousTitles = lbPrevTitles.Items.OfType<string>().ToArray(),
            Links = (Dictionary<string, string>)Resources["PersonLinks"],
            Quotes = (List<Quote>)dgQuotes.ItemsSource
        };

        private void btnEditQuote_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Quote)dgQuotes.SelectedItems[0];
            QuoteWindow window = new QuoteWindow(selected);
            window.ShowDialog();
        }
    }
}
