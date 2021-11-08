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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public long idDoctror;
        Staff doctor;
        public HomePage(Staff staff)
        {
            InitializeComponent();
            idDoctror = staff.Id;
            doctor = staff;
        }

        public HomePage()
        {
            InitializeComponent();
        }


        private void ListOfPatientsBtn(object sender, RoutedEventArgs e)
        {
            ListOfPatients list = new ListOfPatients(doctor);
            this.NavigationService.Navigate(list);
        }

        private void ScheduleBtn(object sender, RoutedEventArgs e)
        {
            Schedule schedule = new Schedule(doctor);
            this.NavigationService.Navigate(schedule);
        }

        private void MedicationBtn(object sender, RoutedEventArgs e)
        {
            MedicationApproving medication = new MedicationApproving(doctor);
            this.NavigationService.Navigate(medication);
        }

        private void ProfileBtn(object sender, RoutedEventArgs e)
        {
          
            Profile profile = new Profile(doctor);
            profile.nameDoctor.Text = doctor.Name;
            profile.lastNameDoctor.Text = doctor.Surname;
            profile.doctorAdrdess.Text = doctor.Adrdess;
            profile.doctorUsername.Text = doctor.Username;
            this.NavigationService.Navigate(profile);
        }

        private void NotificationBtn(object sender, RoutedEventArgs e)
        {
            Notification notification = new Notification(doctor);
            this.NavigationService.Navigate(notification);
        }

        private void FeedbackBtn(object sender, RoutedEventArgs e)
        {
            Feedback feedback = new Feedback(doctor);
            this.NavigationService.Navigate(feedback);
        }

        private void ReportBugBtn(object sender, RoutedEventArgs e)
        {
            ReportBug bug = new ReportBug(doctor);
            this.NavigationService.Navigate(bug);
        }

        private void LogoutBtn(object sender, RoutedEventArgs e)
        {
            
            StaffLoginPage login = new StaffLoginPage();
            this.NavigationService.Navigate(login);

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
