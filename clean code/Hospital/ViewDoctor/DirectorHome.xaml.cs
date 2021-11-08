using Hospital.Model;
using Hospital.ViewDirector;
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
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for DirectorHome.xaml
    /// </summary>
    public partial class DirectorHome : Window
    {
        private Staff loggedInStaff;
        public DirectorHome(Staff staff)
        {
            InitializeComponent();
            loggedInStaff = staff;
        }

        private void btnMedication_Click(object sender, RoutedEventArgs e)
        {
            MedicationView medication = new MedicationView();
            Frejm.NavigationService.Navigate(medication);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SuppliesAndEquipmentView supplies = new SuppliesAndEquipmentView();
            Frejm.NavigationService.Navigate(supplies);

        }

        private void Staff_Click(object sender, RoutedEventArgs e)
        {
            StaffView staff = new StaffView();
            Frejm.NavigationService.Navigate(staff);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DirectorProfileView profile = new DirectorProfileView(loggedInStaff);
            Frejm.NavigationService.Navigate(profile);
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RoomView room = new RoomView();
            Frejm.NavigationService.Navigate(room);
        }
    }
}
