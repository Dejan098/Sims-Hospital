using Controller;
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
    /// Interaction logic for Prescription.xaml
    /// </summary>
    public partial class Prescription : Page
    {
        Hospital.Model.Examination examination;
        private readonly MedicationController _medicationController;
        private ObservableCollection<Medication> medicationList { get; set; }
        private bool Approved = true;
        private Patient patient = new Patient();
        private Staff doctor;
        public Prescription()
        {
            InitializeComponent();
        }
        public Prescription(Hospital.Model.Examination examinationPatient, Patient selectedPatient, Staff staff)
        {
            InitializeComponent();
            var app = Application.Current as App;
            _medicationController = app.MedicationController;

            getMedications();

            doctor = staff;
            examination = examinationPatient;
            patient = selectedPatient;
        }

        private void getMedications()
        {
            try
            {
                medicationList = new ObservableCollection<Medication>(_medicationController.GetApproved(Approved).ToList());
            }
            catch
            {
                MessageBox.Show("Greska");
            }
        }

        private void SubmitBtn(object sender, RoutedEventArgs e)
        {
            setValues();
            Examination examinationBack = new Examination(examination, patient, doctor);
            this.NavigationService.Navigate(examinationBack);
        }

        private void setValues()
        {
            examination.MedicationDosage = dosage.Text;
            examination.IdPatient = patient.Id;
        }
        private void Cancle(object sender, RoutedEventArgs e)
        {
            Examination examinationBack = new Examination(examination, patient, doctor);
            this.NavigationService.Navigate(examinationBack);
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

        private void Medication_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> medication = new List<string>();

            foreach (Medication elem in medicationList)
            {
                medication.Add(elem.Name);
            }

            var combo = sender as ComboBox;
            combo.ItemsSource = medication;
            combo.SelectedIndex = 0;

            examination.MedicationName = combo.Text;
        }


    }
}
