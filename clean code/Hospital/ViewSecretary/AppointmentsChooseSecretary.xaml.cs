using Controller;
using Hospital.Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AppointmentsChooseSecretary.xaml
    /// </summary>
    public partial class AppointmentsChooseSecretary : Page
    {
        private Staff loggedInStaff;
        private Appointment selectedAppointment;
        private long patientId;
        private long roomId;
        private string type;

        private readonly AppointmentController _appointmentController;
        private readonly PatientController _patientController;
        private readonly RoomController _roomController;

        public AppointmentsChooseSecretary(Staff staff, Appointment appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedInStaff = staff;
            selectedAppointment = appointment;

            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;
            _patientController = app.PatientController;
            _roomController = app.RoomController;
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

        private void CancelAddingButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentsAdd page = new AppointmentsAdd(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void ScheduleAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            selectedAppointment.Patient = _patientController.Get(patientId);
            selectedAppointment.Room = _roomController.Get(roomId);
            selectedAppointment.Type = type;
            _appointmentController.ScheduleAppointment(selectedAppointment, "secretary");

            AppointmentsAdd page = new AppointmentsAdd(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        public long Patient1
        {
            get { return patientId; }
            set
            {
                if (patientId != value)
                {
                    patientId = value;
                    OnPropertyChanged("Patient1");
                }
            }
        }

        public long RoomId1
        {
            get { return roomId; }
            set
            {
                if (roomId != value)
                {
                    roomId = value;
                    OnPropertyChanged("RoomId1");
                }
            }
        }

        public string Type1
        {
            get { return type; }
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
