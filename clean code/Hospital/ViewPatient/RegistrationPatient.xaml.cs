using Hospital.Model;
using Hospital.Controller;
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
using System.Windows.Shapes;

namespace Hospital.ViewPatient
{
    /// <summary>
    /// Interaction logic for RegistrationPatient.xaml
    /// </summary>
    public partial class RegistrationPatient : Window
    {
        private string name;
        private string surname;
        private string adrdess;
        private string username;
        private string password;
        private long phoneNumber;
        private long jmbg;

        private readonly PatientController _patientController;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        public string Adrdess1
        {
            get { return adrdess; }
            set
            {
                if (adrdess != value)
                {
                    adrdess = value;
                    OnPropertyChanged("Adrdess1");
                }
            }
        }
        public RegistrationPatient()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _patientController = app.PatientController;
        }
        private Patient CreatePatient()
        {
            Patient patient = new Patient(name, surname, jmbg, adrdess,phoneNumber, username,password);
            return _patientController.RegisterPatient(patient);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = CreatePatient();
        }

        
    }
}
