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
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : Page
    {
        public long idDoctor;
        public Staff doctor;
        private readonly NotificationController _notificationController;
        private ObservableCollection<Hospital.Model.Notification> notificationList { get; set; }
        public Notification(Staff staff)
        {
            InitializeComponent();
            doctor = staff; 

            idDoctor = staff.Id;
            this.DataContext = this;

            var app = Application.Current as App;
            _notificationController = app.NotificationController;

            viewNotification();
            dataGridNotification.ItemsSource = notificationList;
        }

        private void viewNotification()
        {
            try
            {
                notificationList = new ObservableCollection<Hospital.Model.Notification>(_notificationController.GetNotificationsForDoctor(idDoctor).ToList());
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
