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
    /// Interaction logic for Alternative.xaml
    /// </summary>
    public partial class Alternative : Page
    {
        private readonly MedicationController _medicationController;
        private ObservableCollection<Medication> medicationList { get; set; }
        private bool Approved = true;
        Medication selectedMedication;
        private Medication declinedMedication;
        private Staff doctor;
        public Alternative(Medication declined, Staff staff)
        {
            InitializeComponent();
            declinedMedication = declined;

            var app = Application.Current as App;
            _medicationController = app.MedicationController;

            doctor = staff;

            getMedications();
        }

        private void getMedications()
        {
            try
            {
                medicationList = new ObservableCollection<Medication>(_medicationController.GetAll().ToList());
            }
            catch
            {
                MessageBox.Show("Greska");
            }
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            _medicationController.AddAlternativeMedication(declinedMedication, selectedMedication);
            MedicationApproving medication = new MedicationApproving(doctor);
            this.NavigationService.Navigate(medication);
            MessageBox.Show("Medication Declined!");
        }

        private void Cancle(object sender, RoutedEventArgs e)
        {
            MedicationApproving medication = new MedicationApproving(doctor);
            this.NavigationService.Navigate(medication);
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

        private void medicationLoaded(object sender, RoutedEventArgs e)
        {
            List<string> medication = new List<string>();
            
            foreach(Medication elem in medicationList)
            {
                medication.Add(elem.Name);
            }

            var combo = sender as ComboBox;
            combo.ItemsSource = medication;
            combo.SelectedIndex = 0;

           selectedMedication = _medicationController.GetByName(combo.Text);
        }
    }
}
