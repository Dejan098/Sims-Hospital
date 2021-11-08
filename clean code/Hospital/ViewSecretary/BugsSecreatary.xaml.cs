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

namespace Hospital.ViewSecretary
{
    /// <summary>
    /// Interaction logic for BugsSecreatary.xaml
    /// </summary>
    public partial class BugsSecreatary : Page
    {
        private Staff loggedInStaff;
        private readonly FeedbackController _feedbackController;
        private ObservableCollection<Feedback> bugs;

        public BugsSecreatary(Staff staff)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedInStaff = staff;

            var app = Application.Current as App;
            _feedbackController = app.FeedbackController;

            GetAllBugs();
            DataGrid_Feedback.ItemsSource = bugs;
        }

        private void GetAllBugs()
        {
            bugs = new ObservableCollection<Feedback>(_feedbackController.GetAllBugs().ToList());
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
    }
}
