using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.ViewDoctor
{
    /// <summary>
    /// Interaction logic for Operation.xaml
    /// </summary>
    public partial class Operation : Page
    {
        public Operation()
        {
            InitializeComponent();
        }

        private void Schedule(object sender, RoutedEventArgs e)
        {
            File file = new File();
            this.NavigationService.Navigate(file);
        }

        private void Cancle(object sender, RoutedEventArgs e)
        {
            File file = new File();
            this.NavigationService.Navigate(file);
        }

        private void Color(object sender, RoutedEventArgs e)
        {
            Button tb = e.Source as Button;
            tb.Background = Brushes.Coral;
        }

        private void ColorBack(object sender, RoutedEventArgs e)
        {
            Button tb = e.Source as Button;
            tb.Background = Brushes.White;
        }
    }
}
