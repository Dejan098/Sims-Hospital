using Hospital.Controller;
using Hospital.Model;
using Hospital.ViewPatient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for PatientLogin.xaml
    /// </summary>
    public partial class PatientLogin : Window
    {
        private readonly PatientController _patientController;
        Patient patient;

        public PatientLogin()
        {
            InitializeComponent();

            var app = Application.Current as App;
            _patientController = app.PatientController;
        }

        private void registerPatient_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPatient window = new RegistrationPatient();
            window.Show();
            this.Close();
        }

        private void patientLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            patient = _patientController.getByUsernameAndPassword(username, password);

            HomePagePatient window = new HomePagePatient(patient);
            
            window.Show();
            this.Close();
        }
    }
}
