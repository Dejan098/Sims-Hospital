using Hospital.Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
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
    /// Interaction logic for ReportBug.xaml
    /// </summary>
    public partial class ReportBug : Page
    {
        private Staff doctor;
        private readonly FeedbackController _feedackController;
        private ObservableCollection<Model.Feedback> feedbackList { get; set; }
        private string description;
        private bool isBug;
        
        public ReportBug(Staff staff)
        {
            InitializeComponent();
            doctor = staff;
            var app = Application.Current as App;
            _feedackController = app.FeedbackController;

        }

        private void SubmitBtn(object sender, RoutedEventArgs e)
        {
            description = feedbackBox.Text;
            isBug = checkIfBug();

            CreateFeedback(description, isBug);

            HomePage home = new HomePage(doctor);
            this.NavigationService.Navigate(home);
            MessageBox.Show("Feedback sent");
        }

        private void CreateFeedback(string desc, bool bug)
        {
            Model.Feedback feed = new Model.Feedback(description, isBug, doctor);
            _feedackController.AddFeedback(feed);
        }

        private bool checkIfBug()
        {
            if(isbugCheck.IsChecked == true)
            {
                return true;
            }

            return false;
        }

        private void CancleBtn(object sender, RoutedEventArgs e)
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
