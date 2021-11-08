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
    /// Interaction logic for AppointmentUrgentSecretary.xaml
    /// </summary>
    public partial class AppointmentUrgentSecretary : Page
    {
        private Staff loggedInStaff;
        private long doctorId, patientId, roomId, length;
        private string type;

        private readonly AppointmentController _appointmentController;
        private readonly PatientController _patientController;
        private readonly RoomController _roomController;
        private readonly StaffController _staffController;

        public AppointmentUrgentSecretary(Staff staff)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedInStaff = staff;

            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;
            _patientController = app.PatientController;
            _roomController = app.RoomController;
            _staffController = app.StaffController;
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

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = _patientController.Get(patientId);
            Staff staff = _staffController.Get(doctorId);
            Doctor doctor = new Doctor(staff.Name, staff.Surname, staff.Jmbg, staff.Adrdess, staff.PhoneNumber, staff.Username, staff.Password, staff.Salary, staff.Role, staff.Id);
            Room room = _roomController.Get(roomId);
            Appointment newAppointment = new Appointment(dateTimePickerAppointmentsBegin.SelectedDate.Value, dateTimePickerAppointmentsBegin.SelectedDate.Value.AddMinutes(length),
                type, false, true, patient, room, doctor);
            _appointmentController.ScheduleAppointment(newAppointment, "urgent");

            AppointmentsAdd page = new AppointmentsAdd(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public long DoctorId
        {
            get { return doctorId; }
            set
            {
                if (doctorId != value)
                {
                    doctorId = value;
                    OnPropertyChanged("DoctorId");
                }
            }
        }

        public long PatientId
        {
            get { return patientId; }
            set
            {
                if (patientId != value)
                {
                    patientId = value;
                    OnPropertyChanged("PatientId");
                }
            }
        }

        public long RoomId
        {
            get { return roomId; }
            set
            {
                if (roomId != value)
                {
                    roomId = value;
                    OnPropertyChanged("RoomId");
                }
            }
        }

        public long Length
        {
            get { return length; }
            set
            {
                if (length != value)
                {
                    length = value;
                    OnPropertyChanged("Length");
                }
            }
        }

        public string Type
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
    }
}
