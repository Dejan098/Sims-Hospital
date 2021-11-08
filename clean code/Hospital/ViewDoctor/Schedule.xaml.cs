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

namespace Hospital.ViewDoctor
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Page
    {
        private Staff doctor;
        private readonly AppointmentController _appointmentController;
        private ObservableCollection<Appointment> appointments { get; set; }
        public Schedule(Staff staff)
        {
            InitializeComponent();
            doctor = staff;
            this.DataContext = this;
            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;

            GetAllAppointments();
            DataGrid_Appointments.ItemsSource = appointments;
        }

        private void GetAllAppointments()
        {
            appointments = new ObservableCollection<Appointment>(_appointmentController.GetAllDoctorsAppointment(doctor.Id).ToList());
        }

        private void FileBtn(object sender, RoutedEventArgs e)
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

        private void HomePageBtn(object sender, RoutedEventArgs e)
        {
            HomePage home = new HomePage(doctor);
            this.NavigationService.Navigate(home);
        }
    }
}
