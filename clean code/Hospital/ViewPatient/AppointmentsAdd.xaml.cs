using Controller;
using Hospital.Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for AppointmentsAdd.xaml
    /// </summary>
    public partial class AppointmentsAdd : Window
    {

        private Staff loggedInStaff;
        private readonly AppointmentController _appointmentController;
        private readonly StaffController _staffController;
        private ObservableCollection<Appointment> FreeAppointmentsList { get; set; }
        private long doctorId;
       
        public AppointmentsAdd(Patient loggedpatient)
        {
            InitializeComponent();
            this.DataContext = this;
            

            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;
            _staffController = app.StaffController;
        }

        private void GetFreeAppointments()
        {
            ObservableCollection<Appointment> freeAppointments = new ObservableCollection<Appointment>();
            ObservableCollection<Appointment> takenAppointments = new ObservableCollection<Appointment>(_appointmentController.GetAll().ToList());
            Staff staff = _staffController.Get(doctorId);
            Doctor doctor = new Doctor(staff.Name, staff.Surname, staff.Jmbg, staff.Adrdess, staff.PhoneNumber, staff.Username, staff.Password, staff.Salary, staff.Role, staff.Id);

            freeAppointments = new ObservableCollection<Appointment>(_appointmentController.GetFreeAppointments(dateTimePickerAppointmentsBegin.SelectedDate.Value, dateTimePickerAppointmentsEnd.SelectedDate.Value,
                doctor, takenAppointments.ToList()).ToList());

            FreeAppointmentsList = freeAppointments;

        }

        public long Doctor1
        {
            get { return doctorId; }
            set
            {
                if (doctorId != value)
                {
                    doctorId = value;
                    OnPropertyChanged("Doctor1");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void ChooseAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = DataGrid_FreeAppointments.SelectedItem as Appointment;
            ScheduleAppointmentPatient page = new ScheduleAppointmentPatient(appointment);
            page.Show();
        }

        private void listAppointments_Click(object sender, RoutedEventArgs e)
        {
            GetFreeAppointments();
            DataGrid_FreeAppointments.ItemsSource = FreeAppointmentsList;
        }
    }
}
