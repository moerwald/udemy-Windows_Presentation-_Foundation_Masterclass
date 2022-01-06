using EvernoteClone.Model;
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

namespace EvernoteClone.Views.CustomControls
{
    /// <summary>
    /// Interaction logic for DisplayNotebooks.xaml
    /// </summary>
    public partial class DisplayNotebooks : UserControl
    {


        public Notebook Notebook
        {
            get { return (Notebook)GetValue(NotebookProperty); }
            set { SetValue(NotebookProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NotebookProperty =
            DependencyProperty.Register(nameof(Notebook), typeof(Notebook), typeof(DisplayNotebooks), new PropertyMetadata(null, PropertyChanged));



        public DisplayNotebooks()
        {
            InitializeComponent();
        }

        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DisplayNotebooks displayNotebooks)
            {
                displayNotebooks.DataContext = displayNotebooks.Notebook;
            }
        }
    }
}
