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
    /// Interaction logic for PatientAddSecretary.xaml
    /// </summary>
    public partial class PatientAddSecretary : Page
    {
        private Staff loggedInStaff;
        private readonly PatientController _patientController;
        private string name;
        private string surname;
        private long jmbg;
        private string address;
        private long phoneNumber;
        private string username;
        private string password;

        public PatientAddSecretary(Staff staff)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedInStaff = staff;

            var app = Application.Current as App;
            _patientController = app.PatientController;
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

        private void BackToPatients_Click(object sender, RoutedEventArgs e)
        {
            PatientsSecretary page = new PatientsSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void PatientAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Patient patient = CreatePatient();
            }
            catch
            {
                MessageBox.Show("Greska");
            }
            PatientsSecretary page = new PatientsSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }


        private Patient CreatePatient()
        {
            Patient patient = new Patient(name, surname, jmbg, address, phoneNumber, username, password);
            return _patientController.RegisterPatient(patient);
        }

        public string Name1
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name1");
                }
            }
        }

        public string Surname1
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged("Surname1");
                }
            }
        }

        public string Address1
        {
            get { return address; }
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged("Address1");
                }
            }
        }

        public string Username1
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("Username1");
                }
            }
        }

        public string Password1
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password1");
                }
            }
        }

        public long PhoneNumber1
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber1");
                }
            }
        }

        public long Jmbg1
        {
            get { return jmbg; }
            set
            {
                if (jmbg != value)
                {
                    jmbg = value;
                    OnPropertyChanged("Jmbg1");
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
