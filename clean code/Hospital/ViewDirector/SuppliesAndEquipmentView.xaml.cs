using Controller;
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
    /// Interaction logic for SuppliesAndEquipmentView.xaml
    /// </summary>
    public partial class SuppliesAndEquipmentView : Page
    {

        private long id;
        int quantity;
        private string name;
        private long id_Room;

        private StaticEquipment selectedEquipment{ get; set; }



        private readonly SuppliesController _suppliesController;
        private ObservableCollection<Supplies> suppliesList { get; set; }

        private readonly StaticEquipmentController _staticController;

        private readonly RoomController _roomController;

        private Room room = new Room();
        private ObservableCollection<StaticEquipment> staticList { get; set; }

        public SuppliesAndEquipmentView()
        {
            InitializeComponent();

            this.DataContext = this;

            var app = Application.Current as App;
            _suppliesController = app.SuppliesController;
            _staticController = app.StaticController;
            _roomController = app.RoomController;

            getAllSupplies();
            getAllEquipment();
            Grid1.ItemsSource = suppliesList;
            Grid2.ItemsSource = staticList;

        }

        public long Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public long Id_Room
        {
            get { return id_Room; }
            set
            {
                if (id_Room != value)
                {
                    id_Room = value;
                    OnPropertyChanged("Id_Room");
                }
            }
        }
        public string Name1
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name1");
                }
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void getAllSupplies()
        {

            suppliesList = new ObservableCollection<Supplies>(_suppliesController.GetAll().ToList());
           

        }

        private void getAllEquipment()
        {

            staticList = new ObservableCollection<StaticEquipment>(_staticController.GetAll().ToList());


        }

        private void premestiOpremu()
        {
            selectedEquipment = (StaticEquipment)Grid2.SelectedItem;

            room=_roomController.Get(id_Room);

            _staticController.MoveStaticEquipmentFromRoomToRoom(selectedEquipment,room);
        }

        private void poruciStaticku()
        {
            StaticEquipment staticEquipment = new StaticEquipment(Name1);
            room = _roomController.Get(id_Room);

            _staticController.OrderStaticEquipment(staticEquipment, room);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            premestiOpremu();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            poruciStaticku();
        }
    }
}
