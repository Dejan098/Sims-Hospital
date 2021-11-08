using Controller;
using Hospital.Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for RoomView.xaml
    /// </summary>
    /// 
   
    public partial class RoomView : Page
    {
        private readonly RoomController _roomController;

        private readonly AppointmentController _appointmentController;

        private DateTime beginDate;

        private DateTime endDate;

        private Room selectedRoom { get; set; }
        private ObservableCollection<Room> roomList { get; set; }
        private ObservableCollection<Appointment> appointmentList { get; set; }
        public RoomView()
        {
            InitializeComponent();

            this.DataContext = this;

            var app = Application.Current as App;

            _roomController = app.RoomController;

            _appointmentController = app.AppointmentController;

            getAllRooms();

            Grid.ItemsSource = roomList;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DateTime BeginDate
        {
            get { return beginDate; }
            set
            {
                if (beginDate != value)
                {
                    beginDate = value;
                    OnPropertyChanged("BeginDate");
                }
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (endDate != value)
                {
                    endDate = value;
                    OnPropertyChanged("EndDate");
                }
            }
        }

        public void getAllRooms()
        {
            roomList = new ObservableCollection<Room>(_roomController.GetAll().ToList());
        }

        public void renovateRoom(DateTime begin, DateTime end)
        {
            selectedRoom =(Room) Grid.SelectedItem;
            appointmentList = new ObservableCollection<Appointment>(_appointmentController.GetByRoomId(selectedRoom.Id).ToList());
            Boolean isRoomFree = _roomController.isRoomFree(appointmentList,begin,end);

            if (isRoomFree)
            {
                Appointment appointment = new Appointment(selectedRoom,beginDate,endDate);

                _appointmentController.CreateAppointments(appointment);
                

                
            }

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            renovateRoom(BeginDate,EndDate);
        }

        private void BtnRoomApp(object sender, RoutedEventArgs e)
        {
            selectedRoom = (Room)Grid.SelectedItem;
            RoomAppView roomapp = new RoomAppView(selectedRoom);
            this.NavigationService.Navigate(roomapp);
        }
    }
}
