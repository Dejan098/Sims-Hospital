using Hospital.Model;
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

namespace Hospital.ViewSecretary
{
    /// <summary>
    /// Interaction logic for MenuSecretary.xaml
    /// </summary>
    public partial class MenuSecretary : Page
    {
        private Staff loggedInStaff;

        public MenuSecretary(Staff staff)
        {
            InitializeComponent();
            loggedInStaff = staff;
        }

        private void NavigateBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void HomepageButton_Click(object sender, RoutedEventArgs e)
        {
            HomepageSecretary page = new HomepageSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileSecretary page = new ProfileSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void AppointmentsButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentsSecretary page = new AppointmentsSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void PatientsButton_Click(object sender, RoutedEventArgs e)
        {
            PatientsSecretary page = new PatientsSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void AddNewPatientButton_Click(object sender, RoutedEventArgs e)
        {
            PatientAddSecretary page = new PatientAddSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void FAQButton_Click(object sender, RoutedEventArgs e)
        {
            FaqSecretary page = new FaqSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void FeedbackButton_Click(object sender, RoutedEventArgs e)
        {
            FeedbackSecretary page = new FeedbackSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            StaffLoginPage page = new StaffLoginPage();
            this.NavigationService.Navigate(page);
        }

        private void BugsButton_Click(object sender, RoutedEventArgs e)
        {
            BugsSecreatary page = new BugsSecreatary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }
    }
}
