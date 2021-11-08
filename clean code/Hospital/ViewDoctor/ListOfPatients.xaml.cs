using Controller;
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

namespace Hospital.ViewDoctor
{
    /// <summary>
    /// Interaction logic for ListOfPatients.xaml
    /// </summary>
    public partial class ListOfPatients : Page
    {
        private readonly PatientController _patientController;
        private ObservableCollection<Patient> patientsList { get; set; }
        private Patient selectedPatient = new Patient();
        Staff doctor;
        public ListOfPatients(Staff staff)
        {
            InitializeComponent();

            var app = Application.Current as App;
            _patientController = app.PatientController;
            doctor = staff;
            viewPatients();
            dataGridPacijenti.ItemsSource = patientsList;

        }


        private void viewPatients()
        {
            try
            {
                patientsList = new ObservableCollection<Patient>(_patientController.GetAll().ToList()) ;
            }
            catch
            {
                MessageBox.Show("Greska");
            }
        }

        private void HomePageBtn(object sender, RoutedEventArgs e)
        {
            HomePage home = new HomePage(doctor);
            this.NavigationService.Navigate(home);
        }

        private void FileBtn(object sender, RoutedEventArgs e)
        {
            selectedPatient = (Patient)dataGridPacijenti.SelectedItem;

            File file = new File(selectedPatient, doctor);

            file.patientName.Text = selectedPatient.Name;
            file.patientSurname.Text = selectedPatient.Surname;
            file.patientJmbg.Text = selectedPatient.Jmbg.ToString();

            this.NavigationService.Navigate(file);
        }

        private void Color(object sender, RoutedEventArgs e)
        {
            Button tb = e.Source as Button;
            tb.Background = Brushes.Coral;
        }

        private void ColorBack(object sender, RoutedEventArgs e)
        {
            Button tb = e.Source as Button;
            tb.Background = Brushes.White;
        }
    }
}
