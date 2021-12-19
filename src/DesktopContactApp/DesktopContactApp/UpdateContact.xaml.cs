using DesktopContactApp.Model;
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

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for UpdateContact.xaml
    /// </summary>
    public partial class UpdateContact : Window
    {
        private readonly Contact _contact;

        public UpdateContact(Contact contact)
        {
            InitializeComponent();
            _contact = contact;
            NameTextBox.Text = _contact.Name;
            EmailTextBox.Text = _contact.Email;
            PhoneTextBox.Text = _contact.Phone;


            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
            => 
            PerformDbOpterationAndCloseThisWindow( c => c.Update(new Contact
            {
                Id = _contact.Id,
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text,
                Phone = PhoneTextBox.Text,
            }));

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
            => 
            PerformDbOpterationAndCloseThisWindow(c => c.Delete(_contact));

        private void PerformDbOpterationAndCloseThisWindow(Action<SQLite.SQLiteConnection> action)
        {
            PerformDbOperation.Perform(action);
            Close();
        }
    }
}
