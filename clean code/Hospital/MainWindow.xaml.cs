using Hospital.Controller;
using Hospital.Model;
using Hospital.ViewDoctor;
using Hospital.ViewPatient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppointmentController _appointmentController;
        private ObservableCollection<Appointment> appointmentList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;

        }


        private void patientLogin_Click(object sender, RoutedEventArgs e)
        {
            PatientLogin window = new PatientLogin();
            window.Show();
            this.Close();
        }

        private void staffLogin_Click(object sender, RoutedEventArgs e)
        {
            StaffLogin window = new StaffLogin();
            window.Show();
            this.Close();
        }
    }
}
