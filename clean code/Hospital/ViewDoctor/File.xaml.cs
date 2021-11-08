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
    /// Interaction logic for File.xaml
    /// </summary>
    public partial class File : Page
    {
        private Patient patient = new Patient();
        private Staff doctor;
        public File()
        {
            InitializeComponent();
        }

        public File(Patient patientSelected, Staff staff)
        {
            InitializeComponent();
            patient = patientSelected;
            doctor = staff;
        }

        private void ExaminationBtn(object sender, RoutedEventArgs e)
        {
            Examination examination = new Examination(patient, doctor);
            this.NavigationService.Navigate(examination);
        }

        private void ScheduleOperation(object sender, RoutedEventArgs e)
        {
            Operation operation = new Operation();
            this.NavigationService.Navigate(operation);
        }

        private void IllnessHistory(object sender, RoutedEventArgs e)
        {
            IllnessHistory illnessHistory = new IllnessHistory(doctor, patient);
            illnessHistory.name.Content = patient.Name;
            illnessHistory.surname.Content = patient.Surname;
            this.NavigationService.Navigate(illnessHistory);
        }

        private void Report(object sender, RoutedEventArgs e)
        {

        }

        private void Home(object sender, RoutedEventArgs e)
        {
            HomePage home = new HomePage(doctor);
            this.NavigationService.Navigate(home);
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
