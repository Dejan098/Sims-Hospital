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
    /// Interaction logic for AppointmentsChangeSecretary.xaml
    /// </summary>
    public partial class AppointmentsChangeSecretary : Page
    {
        private Staff loggedInStaff;
        private Appointment selectedAppointment;
        private readonly AppointmentController _appointmentController;
        private readonly NotificationController _notificationController;

        public AppointmentsChangeSecretary(Staff staff, Appointment appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedInStaff = staff;
            selectedAppointment = appointment;

            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;
            _notificationController = app.NotificationController;
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileSecretary page = new ProfileSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuSecretary page = new MenuSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void CancelChangeAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentsSecretary page = new AppointmentsSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void ApplyChangesAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            _appointmentController.Update(selectedAppointment);
            AppointmentsSecretary page = new AppointmentsSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        public long Patient1
        {
            get { return selectedAppointment.Patient.Id; }
            set
            {
                if (selectedAppointment.Patient.Id != value)
                {
                    selectedAppointment.Patient.Id = value;
                    OnPropertyChanged("Patient1");
                }
            }
        }

        public long Doctor1
        {
            get { return selectedAppointment.Doctor.Id; }
            set
            {
                if (selectedAppointment.Doctor.Id != value)
                {
                    selectedAppointment.Doctor.Id = value;
                    OnPropertyChanged("Doctor1");
                }
            }
        }

        public long Room1
        {
            get { return selectedAppointment.Room.Id; }
            set
            {
                if (selectedAppointment.Room.Id != value)
                {
                    selectedAppointment.Room.Id = value;
                    OnPropertyChanged("Room1");
                }
            }
        }

        public string Type1
        {
            get { return selectedAppointment.Type; }
            set
            {
                if (selectedAppointment.Type != value)
                {
                    selectedAppointment.Type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public DateTime BeginningOfAppointment1
        {
            get { return selectedAppointment.BeginningOfAppointment; }
            set
            {
                if (selectedAppointment.BeginningOfAppointment != value)
                {
                    selectedAppointment.BeginningOfAppointment = value;
                    OnPropertyChanged("BeginningOfAppointment1");
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
