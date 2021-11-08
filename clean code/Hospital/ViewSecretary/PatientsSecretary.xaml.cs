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

namespace Hospital.ViewSecretary
{
    /// <summary>
    /// Interaction logic for PatientsSecretary.xaml
    /// </summary>
    public partial class PatientsSecretary : Page
    {
        private Staff loggedInStaff;
        private readonly PatientController _patientController;
        private ObservableCollection<Patient> patients { get; set; }

        public PatientsSecretary(Staff staff)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedInStaff = staff;

            var app = Application.Current as App;
            _patientController = app.PatientController;

            GetAllPatients();
            DataGrid_Patients.ItemsSource = patients;
        }

        private void GetAllPatients()
        {
            patients = new ObservableCollection<Patient>(_patientController.GetAll().ToList());
        }

        private void PatientButton_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPatient = (Patient)DataGrid_Patients.SelectedItem;
            PatientViewSecretary page = new PatientViewSecretary(loggedInStaff, selectedPatient);
            this.NavigationService.Navigate(page);
        }

        private void AddNewPatientButton_Click(object sender, RoutedEventArgs e)
        {
            PatientAddSecretary page = new PatientAddSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
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
    }
}
