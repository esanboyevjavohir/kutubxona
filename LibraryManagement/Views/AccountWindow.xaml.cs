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

namespace LibraryManagement.Views
{
    /// <summary>
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        public AccountWindow()
        {
            InitializeComponent();
        }

        private void OnClickEdit(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow();
            editWindow.Show();
        }

        private void HistoryClicked(object sender, RoutedEventArgs e)
        {

        }

        private void LogOutClicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
