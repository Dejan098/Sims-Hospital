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
    /// Interaction logic for MedicationView.xaml
    /// </summary>
    public partial class MedicationView : Page
    {
        private long id;
        int quantity;
        private string name;
        private string code;
        private readonly MedicationController _medicationController;
        private Medication selectedMedication { get; set; }
        private ObservableCollection<Medication> medicationList { get; set; }
        public MedicationView()
        {
            InitializeComponent();

            this.DataContext = this;

            var app = Application.Current as App;
            _medicationController = app.MedicationController;

            getAllMedication();
            Grid.ItemsSource = medicationList;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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


        public string Code
        {
            get { return code; }
            set
            {
                if (code != value)
                {
                    code = value;
                    OnPropertyChanged("Code");
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



        private Medication CreateMedication()
        {
            Medication medication = new Medication(id, name, code);

            return _medicationController.RegisterMedication(medication);
        }

        private void poruciLekove()
        {
            selectedMedication = (Medication)Grid.SelectedItem;
            _medicationController.OrderMedication(selectedMedication, quantity);
        }

        private void getAllMedication()
        {

            medicationList = new ObservableCollection<Medication>(_medicationController.GetAll().ToList());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Medication medication = CreateMedication();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            poruciLekove();
        }
    }
}