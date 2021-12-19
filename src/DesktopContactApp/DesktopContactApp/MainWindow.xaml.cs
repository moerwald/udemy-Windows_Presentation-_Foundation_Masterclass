using DesktopContactApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> _contacts = new();

        public MainWindow()
        {
            InitializeComponent();
            ReadDatabaseAndUpdateListView();
        }

        private void NewContact_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindows window = new();
            window.ShowDialog();
            ReadDatabaseAndUpdateListView();
        }

        private void ReadDatabaseAndUpdateListView()
        {
            PerformDbOperation.Perform(c =>
            {
                _contacts = c.Table<Contact>().OrderBy(contact => contact.Name).ToList();
                ListViewContacts.ItemsSource = _contacts;
            });
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? searchTextBox = sender as TextBox;
            var filteredList = _contacts.Where(
                c => c.Name.Contains(searchTextBox?.Text ?? string.Empty,
                                     StringComparison.InvariantCultureIgnoreCase)).ToList();
            ListViewContacts.ItemsSource = filteredList;
        }

        private void ListViewContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ListViewContacts.SelectedItem as Contact;
            if (selectedItem != null)
            {
                var wnd = new UpdateContact(selectedItem);
                wnd.ShowDialog();
                ReadDatabaseAndUpdateListView();
            }
        }
    }
}
