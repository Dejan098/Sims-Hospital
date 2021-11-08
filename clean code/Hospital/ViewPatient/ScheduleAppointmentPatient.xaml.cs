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
using System.Windows.Shapes;

namespace Hospital.ViewPatient
{
    /// <summary>
    /// Interaction logic for ScheduleAppointmentPatient.xaml
    /// </summary>
    public partial class ScheduleAppointmentPatient : Window
    {
        private Patient loggedInStaff;
        private readonly AppointmentController _appointmentController;
        private ObservableCollection<Appointment> appointments { get; set; }
        public ScheduleAppointmentPatient() {
            InitializeComponent();
            this.DataContext = this;


            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;

            GetAllAppointments();
            DataGrid_Appointments.ItemsSource = appointments;
        }


        public ScheduleAppointmentPatient(Appointment appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            

            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;

            GetAllAppointments();
            DataGrid_Appointments.ItemsSource = appointments;
        }
        private void GetAllAppointments()
        {
            appointments = new ObservableCollection<Appointment>(_appointmentController.GetAll().ToList());
        }

        private void AddAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentsAdd win = new AppointmentsAdd(loggedInStaff);
            win.Show();
        }
    }
}
