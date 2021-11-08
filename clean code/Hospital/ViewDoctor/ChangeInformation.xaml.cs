using Controller;
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
    /// Interaction logic for ChangeInformation.xaml
    /// </summary>
    public partial class ChangeInformation : Page
    {
        Staff doctor;
        private readonly StaffController _staffController;

        public ChangeInformation()
        {
            InitializeComponent();
        }

        public ChangeInformation(Staff doc)
        {
            InitializeComponent();
            var app = Application.Current as App;
            _staffController = app.StaffController;
            doctor = doc;
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            
            doctor.Name = nameDoctor.Text;
            doctor.Surname = surnameDoctor.Text;
            doctor.Adrdess = addressDoctor.Text;
            doctor.Username = usernameDoctor.Text;
            _staffController.Update(doctor);

            Profile profile = new Profile(doctor);
            this.NavigationService.Navigate(profile);
        }

        private void Cancle(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(doctor);
            this.NavigationService.Navigate(profile);
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
