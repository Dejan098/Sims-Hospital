using Hospital.Model;
using Hospital.ViewDoctor;
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
    /// Interaction logic for ProfileSecretary.xaml
    /// </summary>
    public partial class ProfileSecretary : Page
    {
        private Staff loggedInStaff;

        public ProfileSecretary(Staff staff)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedInStaff = staff;
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

        private void ChangeProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileChangeSecretary page = new ProfileChangeSecretary(loggedInStaff);
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
    }
}
