using Hospital.Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for PatientsFilter.xaml
    /// </summary>
    public partial class PatientsFilter : Page
    {
        private Staff loggedInStaff;
        private readonly PatientController _patientController;
        private ObservableCollection<Patient> patients { get; set; }
        private long id;


        public PatientsFilter(Staff staff)
        {
            InitializeComponent();
            loggedInStaff = staff;

            var app = Application.Current as App;
            _patientController = app.PatientController;
            patients = new ObservableCollection<Patient>(_patientController.GetAll().ToList());
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuSecretary page = new MenuSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileSecretary page = new ProfileSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void nameComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<string> names = new ObservableCollection<string>();

            foreach(Patient patient in patients)
            {
                names.Add(patient.Name);
            }

            nameComboBox.ItemsSource = names;
        }

        private void surnameComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<string> surnames = new ObservableCollection<string>();

            foreach (Patient patient in patients)
            {
                surnames.Add(patient.Surname);
            }

            surnameComboBox.ItemsSource = surnames;
        }

        private void usernameComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<string> usernames = new ObservableCollection<string>();

            foreach (Patient patient in patients)
            {
                usernames.Add(patient.Username);
            }

            usernameComboBox.ItemsSource = usernames;
        }

        private void CancelFilterButton_Click(object sender, RoutedEventArgs e)
        {
            PatientsSecretary page = new PatientsSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            patients = new ObservableCollection<Patient>(_patientController.GetByNameSurnameUsernameAndId((string)nameComboBox.SelectedItem,
                (string)surnameComboBox.SelectedItem, (string)usernameComboBox.SelectedItem, id));

            MessageBox.Show((string)nameComboBox.SelectedItem);

            PatientsSecretary page = new PatientsSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
            page.DataGrid_Patients.ItemsSource = patients;
        }

        public long Id1
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id1");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
