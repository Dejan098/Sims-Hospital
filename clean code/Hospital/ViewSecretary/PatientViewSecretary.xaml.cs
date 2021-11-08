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
    /// Interaction logic for PatientViewSecretary.xaml
    /// </summary>
    public partial class PatientViewSecretary : Page
    {
        private Staff loggedInStaff;
        private Patient selectedPatient;

        public PatientViewSecretary(Staff staff, Patient patient)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedInStaff = staff;
            selectedPatient = patient;
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

        private void BackToPatients_Click(object sender, RoutedEventArgs e)
        {
            PatientsSecretary page = new PatientsSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void ChangePatientsProfile_Click(object sender, RoutedEventArgs e)
        {
            PatientChangeSecretary page = new PatientChangeSecretary(loggedInStaff, selectedPatient);
            this.NavigationService.Navigate(page);
        }

        public string Name1
        {
            get { return selectedPatient.Name; }
            set
            {
                if (selectedPatient.Name != value)
                {
                    selectedPatient.Name = value;
                    OnPropertyChanged("Name1");
                }
            }
        }

        public string Surname
        {
            get { return selectedPatient.Surname; }
            set
            {
                if (selectedPatient.Surname != value)
                {
                    selectedPatient.Surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }

        public string Address
        {
            get { return selectedPatient.Adrdess; }
            set
            {
                if (selectedPatient.Adrdess != value)
                {
                    selectedPatient.Adrdess = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        public string Username
        {
            get { return selectedPatient.Username; }
            set
            {
                if (selectedPatient.Username != value)
                {
                    selectedPatient.Username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Password
        {
            get { return selectedPatient.Password; }
            set
            {
                if (selectedPatient.Password != value)
                {
                    selectedPatient.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public long PhoneNumber
        {
            get { return selectedPatient.PhoneNumber; }
            set
            {
                if (selectedPatient.PhoneNumber != value)
                {
                    selectedPatient.PhoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        public long Jmbg
        {
            get { return selectedPatient.Jmbg; }
            set
            {
                if (selectedPatient.Jmbg != value)
                {
                    selectedPatient.Jmbg = value;
                    OnPropertyChanged("Jmbg");
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
