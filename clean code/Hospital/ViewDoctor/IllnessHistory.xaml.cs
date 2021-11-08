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
    /// Interaction logic for IllnessHistory.xaml
    /// </summary>
    public partial class IllnessHistory : Page
    {
        private Staff doctor;
        private Patient patient;
        private readonly ExaminationController _examinationController;
        private ObservableCollection<Hospital.Model.Examination> examinationList { get; set; }

        public IllnessHistory(Staff staff, Patient patients)
        {
            InitializeComponent();
            doctor = staff;
            patient = patients;
            this.DataContext = this;

            var app = Application.Current as App;
            _examinationController = app.ExaminationController;

            viewExaminations();
            dataGridPacijenti.ItemsSource = examinationList;
        }

        private void viewExaminations()
        {
            try
            {
                examinationList = new ObservableCollection<Hospital.Model.Examination>(_examinationController.GetByPatientId(patient.Id).ToList());
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
    }
}
