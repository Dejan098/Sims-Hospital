using Controller;
using Hospital.Controller;
using Hospital.Model;
using Hospital.ViewDoctor;
using Hospital.ViewSecretary;
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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for StaffLoginPage.xaml
    /// </summary>
    public partial class StaffLoginPage : Page
    {

        private readonly StaffController _staffController;
        Staff staff;

        public StaffLoginPage()
        {
            InitializeComponent();

            var app = Application.Current as App;
            _staffController = app.StaffController;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            staff = _staffController.getByUsernameAndPassword(username, password);
            if (staff.Role == "secretary")
            {
                HomepageSecretary page = new HomepageSecretary(staff);
                this.NavigationService.Navigate(page);
            }
            else if (staff.Role == "doctor")
            {
                HomePage homepage = new HomePage(staff);
                this.NavigationService.Navigate(homepage);
            }
            else if (staff.Role == "director")
            {
                DirectorHome homepage = new DirectorHome(staff);
                homepage.Show();
            }
        }
    }
}
