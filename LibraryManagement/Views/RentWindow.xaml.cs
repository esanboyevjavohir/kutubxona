﻿using System;
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
    /// Interaction logic for RentWindow.xaml
    /// </summary>
    public partial class RentWindow : Window
    {
        public RentWindow()
        {
            InitializeComponent();
        }

        private void IjaragaBerish(object sender, RoutedEventArgs e)
        {
            Kuni kuni = new Kuni();
            kuni.Show();
        }

        private void TellNumber(object sender, RoutedEventArgs e)
        {

        }

        private void OnClickPassword(object sender, RoutedEventArgs e)
        {

        }
    }
}
