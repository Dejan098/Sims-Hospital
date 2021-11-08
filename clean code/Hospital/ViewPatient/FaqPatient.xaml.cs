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
using System.Windows.Shapes;
using Hospital.Model;
using Hospital.Controller;
using Controller;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Navigation;
using Hospital.ViewDoctor;

namespace Hospital.ViewPatient
{
    /// <summary>
    /// Interaction logic for FaqPatient.xaml
    /// </summary>
    /// private readonly PatientController _patientController;

    public partial class FaqPatient : Window
    {
        private string description;
        private Boolean isBug;
        private string question;
        private DateTime BeginningOfAppointment1;
        private DateTime EndOfAppointment1;
        private Boolean IsFree1 = true;
        private Boolean IsUrgent1 = false;
        private readonly FaqController _faqController;
        private readonly AppointmentController _appointmentController;
        private readonly FeedbackController _feedackController;
        private ObservableCollection<Faq> faqList { get; set; }
        private ObservableCollection<Model.Feedback> feedbackList { get; set; }
        private Patient loggedPatient;
        public FaqPatient(Patient patient)
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            _faqController = app.FaqController;
            _feedackController = app.FeedbackController;
            GetAllFaqs();
            Grid_faq.ItemsSource = faqList;
            loggedPatient = patient;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Boolean IsBug
        {
            get { return isBug; }
            set
            {
                if ( isBug!= value)
                {
                    isBug = value;
                    OnPropertyChanged("IsBug");
                }
            }
        }
        public string Question
        {
            get { return question; }
            set
            {
                if (question != value)
                {
                    question = value;
                    OnPropertyChanged("Question");
                }
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
       
        private void GetAllFaqs()
        {
            faqList = new ObservableCollection<Faq> (_faqController.getAllFaqsAnswered().ToList());

        }
        private Faq CreateFaq()
        {
            Faq faq = new Faq(loggedPatient,question);
            return _faqController.AddFAQ(faq);
        }
       
        private Model.Feedback CreateFeedback()
        {
            Model.Feedback feed = new Model.Feedback(description,false,loggedPatient as RegisteredUser);
            return _feedackController.AddFeedback(feed);
        }
        private Appointment CreateAppoinemnt()
        {

            Appointment app = new Appointment(BeginningOfAppointment1,EndOfAppointment1);

            return _appointmentController.CreateAppointments(app);
        }

        private void FaqConfirm_Click(object sender, RoutedEventArgs e)
        {

            CreateFaq();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.Feedback feed = CreateFeedback();
        }

        
    }
}
