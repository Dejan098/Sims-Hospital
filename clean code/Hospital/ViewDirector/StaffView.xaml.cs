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

namespace Hospital.ViewDirector
{
    /// <summary>
    /// Interaction logic for StaffView.xaml
    /// </summary>
    public partial class StaffView : Page
    {
        private readonly StaffController _staffController;
        private ObservableCollection<Staff> staffList { get; set; }

        public StaffView()
        {
            InitializeComponent();

            this.DataContext = this;

            var app = Application.Current as App;
            _staffController = app.StaffController;

            getAllStaff();
            Grid.ItemsSource = staffList;

        }

        public void getAllStaff()
        {
            staffList = new ObservableCollection<Staff>(_staffController.GetAll().ToList());
        }
    }
}
