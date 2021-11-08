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
    /// Interaction logic for IsAppointmentUrgentSecretary.xaml
    /// </summary>
    public partial class IsAppointmentUrgentSecretary : Page
    {
        private Staff loggedInStaff;

        public IsAppointmentUrgentSecretary(Staff staff)
        {
            InitializeComponent();
        }

        private void regularAppointment_Click(object sender, RoutedEventArgs e)
        {
            AppointmentsAdd page = new AppointmentsAdd(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void urgentAppointment_Click(object sender, RoutedEventArgs e)
        {
            AppointmentUrgentSecretary page = new AppointmentUrgentSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }
    }
}
