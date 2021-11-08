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
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for StaffLogin.xaml
    /// </summary>
    public partial class StaffLogin : Window
    {
        public StaffLogin()
        {
            InitializeComponent();
            StaffLoginPage page = new StaffLoginPage();
            MainFrame.NavigationService.Navigate(page);
        }
    }
}
