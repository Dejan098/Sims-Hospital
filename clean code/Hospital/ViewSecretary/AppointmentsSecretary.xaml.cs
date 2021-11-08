using Hospital.Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// Interaction logic for AppointmentsSecretary.xaml
    /// </summary>
    public partial class AppointmentsSecretary : Page
    {
        private Staff loggedInStaff;
        private readonly AppointmentController _appointmentController;
        private ObservableCollection<Appointment> appointments { get; set; }

        public AppointmentsSecretary(Staff staff)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedInStaff = staff;

            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;

            GetAllAppointments();
            DataGrid_Appointments.ItemsSource = appointments;
        }

        private void GetAllAppointments()
        {
            appointments = new ObservableCollection<Appointment>(_appointmentController.GetAll().ToList());
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuSecretary page = new MenuSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileSecretary page = new ProfileSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void AddAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            IsAppointmentUrgentSecretary page = new IsAppointmentUrgentSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void ChangeAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Appointment selectedAppointment = (Appointment)DataGrid_Appointments.SelectedItem;
            AppointmentsChangeSecretary page = new AppointmentsChangeSecretary(loggedInStaff, selectedAppointment);
            this.NavigationService.Navigate(page);
        }

        private void CancelAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment selectedAppointment = (Appointment)DataGrid_Appointments.SelectedItem;
            _appointmentController.Delete(selectedAppointment);

            AppointmentsSecretary page = new AppointmentsSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

    }
}
