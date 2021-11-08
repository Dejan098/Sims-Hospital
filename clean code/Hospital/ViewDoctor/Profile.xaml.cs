using Hospital.Model;
using Microsoft.Win32.SafeHandles;
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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Staff doc;
        public Profile(Staff doctor)
        {
            InitializeComponent();
            doc = doctor;
            nameDoctor.Text = doctor.Name;
            lastNameDoctor.Text = doctor.Surname;
            doctorAdrdess.Text = doctor.Adrdess;
            doctorUsername.Text = doctor.Username;
        }
        public Profile()
        {
            InitializeComponent();
        }
        private void ChangeInfoBtn(object sender, RoutedEventArgs e)
        {

            ChangeInformation changeInformation = new ChangeInformation(doc);
            changeInformation.nameDoctor.Text = doc.Name;
            changeInformation.surnameDoctor.Text = doc.Surname;
            changeInformation.addressDoctor.Text = doc.Adrdess;
            changeInformation.usernameDoctor.Text = doc.Username;
            this.NavigationService.Navigate(changeInformation);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            HomePage home = new HomePage(doc);
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
