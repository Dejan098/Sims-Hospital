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
    /// Interaction logic for MedicationApproving.xaml
    /// </summary>
    public partial class MedicationApproving : Page
    {
        private readonly MedicationController _medicationController;
        private ObservableCollection<Medication> medicationList { get; set; }
        private Medication selectedMedication { get; set; }
        private Staff doctor;
        public MedicationApproving(Staff staff)
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _medicationController = app.MedicationController;
            doctor = staff;

            viewMedications();
          
            dataGridMedication.ItemsSource = medicationList;

        }


        private void viewMedications()
        {
            try
            {
                medicationList = new ObservableCollection<Medication>(_medicationController.GetForApproval().ToList());
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

        private void Approve(object sender, RoutedEventArgs e)
        {
            selectedMedication = (Medication)dataGridMedication.SelectedItem;
   
            _medicationController.ApproveMedication(selectedMedication);
            medicationList.Remove((Medication)selectedMedication);
            MessageBox.Show("Medication Approved!");

            /* var selectedItem = dataGridMedication.SelectedItem;
             if (selectedItem == null)
             {
                 return;
             }
             Medications.Remove((Medications)selectedItem);
             MessageBox.Show("Medication Approved!");*/
        }

        private void Decline(object sender, RoutedEventArgs e)
        {
            selectedMedication = (Medication)dataGridMedication.SelectedItem;

            _medicationController.DeclineMedication(selectedMedication);

            Alternative alternative = new Alternative(selectedMedication, doctor);
            this.NavigationService.Navigate(alternative);
            alternative.declined.Text = selectedMedication.Name;
         
            /* var selectedItem = dataGridMedication.SelectedItem;
             if (selectedItem == null)
             {
                 return;
             }
             Medications.Remove((Medications)selectedItem);
             Alternative alternative = new Alternative();
             this.NavigationService.Navigate(alternative);*/
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
