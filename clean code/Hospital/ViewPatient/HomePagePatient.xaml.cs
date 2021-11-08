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
using System.Windows.Shapes;

namespace Hospital.ViewPatient
{
    /// <summary>
    /// Interaction logic for HomePagePatient.xaml
    /// </summary>
    public partial class HomePagePatient : Window
    {
        private string username;
        private string name;
        private string surname;
        private string address;
        private Patient loggedPatient;
        public HomePagePatient(Patient patient)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedPatient = patient;

            username = patient.Username;
            name = patient.Name;
            surname = patient.Surname;
            address = patient.Adrdess;
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FaqPatient win = new FaqPatient(loggedPatient);
            win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ScheduleAppointmentPatient win = new ScheduleAppointmentPatient();
            win.Show();
        }
    }
}
