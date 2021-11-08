using Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ProfileChangeSecretary.xaml
    /// </summary>
    public partial class ProfileChangeSecretary : Page
    {
        private Staff loggedInStaff;
        private string passwordConfirm;
        private readonly StaffController _staffController;

        public ProfileChangeSecretary(Staff staff)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedInStaff = staff;

            var app = Application.Current as App;
            _staffController = app.StaffController;
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileSecretary page = new ProfileSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuSecretary page = new MenuSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        public string Name1
        {
            get { return loggedInStaff.Name + " " + loggedInStaff.Surname; }
            set
            {
                if (loggedInStaff.Name != value)
                {
                    loggedInStaff.Name = value;
                    OnPropertyChanged("Name1");
                }
            }
        }

        public string Address1
        {
            get { return loggedInStaff.Adrdess; }
            set
            {
                if (loggedInStaff.Adrdess != value)
                {
                    loggedInStaff.Adrdess = value;
                    OnPropertyChanged("Address1");
                }
            }
        }

        public string Username1
        {
            get { return loggedInStaff.Username; }
            set
            {
                if (loggedInStaff.Username != value)
                {
                    loggedInStaff.Username = value;
                    OnPropertyChanged("Username1");
                }
            }
        }

        public string Password1
        {
            get { return loggedInStaff.Password; }
            set
            {
                if (loggedInStaff.Password != value)
                {
                    loggedInStaff.Password = value;
                    OnPropertyChanged("Password1");
                }
            }
        }

        public string PasswordConfirm
        {
            get { return passwordConfirm; }
            set
            {
                if (passwordConfirm != value)
                {
                    passwordConfirm = value;
                    OnPropertyChanged("PasswordConfirm");
                }
            }
        }

        public long PhoneNumber1
        {
            get { return loggedInStaff.PhoneNumber; }
            set
            {
                if (loggedInStaff.PhoneNumber != value)
                {
                    loggedInStaff.PhoneNumber = value;
                    OnPropertyChanged("PhoneNumber1");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SaveChangesToProfile_Click(object sender, RoutedEventArgs e)
        {
            _staffController.Update(loggedInStaff);
            ProfileSecretary page = new ProfileSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }
    }
}
