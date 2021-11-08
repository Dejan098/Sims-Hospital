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

namespace Hospital.ViewDirector
{
    /// <summary>
    /// Interaction logic for RoomAppView.xaml
    /// </summary>
    public partial class RoomAppView : Page
    {
        private readonly AppointmentController _appointmentController;

        private ObservableCollection<Appointment> appointmentList { get; set; }
        public RoomAppView()
        {
            InitializeComponent();
        }

        public RoomAppView(Room room)
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;

            getAllAppointments(room);
            Grid.ItemsSource = appointmentList;
        }

        public void getAllAppointments(Room room)
        {
            appointmentList= new ObservableCollection<Appointment>(_appointmentController.GetByRoomId(room.Id).ToList());
        }
    }
}
