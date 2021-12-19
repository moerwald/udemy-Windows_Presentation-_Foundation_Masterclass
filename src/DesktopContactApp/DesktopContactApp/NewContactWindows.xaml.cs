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
using SQLite;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for NewContactWindows.xaml
    /// </summary>
    public partial class NewContactWindows : Window
    {
        public NewContactWindows()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            var contact = new Contact
            {
                Email = emailTb.Text,
                Name = nameTb.Text,
                Phone = phoneTb.Text,
            };

            using var connection = new SQLiteConnection(Database.DbPath.Get());
            connection.CreateTable<Contact>();
            connection.Insert(contact);


            Close();
        }

    }
}
