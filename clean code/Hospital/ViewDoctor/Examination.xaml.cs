using Hospital.Controller;
using Hospital.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.ViewDoctor
{
    /// <summary>
    /// Interaction logic for Examination.xaml
    /// </summary>
    public partial class Examination : Page
    {
        //private Patient patient;
        private Hospital.Model.Examination examinationPatient = new Model.Examination();
        private readonly ExaminationController _examinationController;
        private Patient patient = new Patient();
        private Staff doctor;
        //private Examination examination;
        public Examination()
        {
            InitializeComponent();
        }

        public Examination(Patient selectedPatient, Staff staff)
        {
            InitializeComponent();
            var app = Application.Current as App;
            _examinationController = app.ExaminationController;

            patient = selectedPatient;
            doctor = staff;
            
        }

        public Examination(Model.Examination examination, Patient selectedPatient, Staff staff)
        {
            InitializeComponent();
            var app = Application.Current as App;
            _examinationController = app.ExaminationController;

            patient = selectedPatient;
            doctor = staff;

            examinationPatient.MedicationName = examination.MedicationName;
            examinationPatient.MedicationDosage = examination.MedicationDosage;
            examinationPatient.IdPatient = examination.IdPatient;

        }

        private void Prescription(object sender, RoutedEventArgs e)
        {
            Prescription prescription = new Prescription(examinationPatient, patient, doctor);
            this.NavigationService.Navigate(prescription);
            
        }

        private void Checkup(object sender, RoutedEventArgs e)
        {
            Checkup checkup = new Checkup();
            this.NavigationService.Navigate(checkup);
        }

        private void Specialist(object sender, RoutedEventArgs e)
        {
            Specialist specialist = new Specialist();
            this.NavigationService.Navigate(specialist);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            File file = new File(patient, doctor);

            file.patientName.Text = patient.Name;
            file.patientSurname.Text = patient.Surname;
            file.patientJmbg.Text = patient.Jmbg.ToString();

            this.NavigationService.Navigate(file);
        }

        private void File(object sender, RoutedEventArgs e)
        {
            File file = new File(patient, doctor);
            saveExamination();

            file.patientName.Text = patient.Name;
            file.patientSurname.Text = patient.Surname;
            file.patientJmbg.Text = patient.Jmbg.ToString();

            this.NavigationService.Navigate(file);
        }

        public void saveExamination()
        {
            examinationPatient.Anamnesis = anamnesis.Text;

            _examinationController.Create(examinationPatient);
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
