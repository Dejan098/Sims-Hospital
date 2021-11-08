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
    /// Interaction logic for FaqAnswer.xaml
    /// </summary>
    public partial class FaqAnswerSecretary : Page
    {
        private Staff loggedInStaff;
        private readonly FaqController _faqController;
        private string faqResponse;
        private string question;
        private Faq faq;

        public FaqAnswerSecretary(Staff staff, Faq selectedFaq)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedInStaff = staff;
            faq = selectedFaq;
            question = faq.Question;

            var app = Application.Current as App;
            _faqController = app.FaqController;
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

        private void RespondToQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            faq.Answer = faqResponse;
            _faqController.AnswerFaq(faq);
            FaqSecretary page = new FaqSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        private void ExitResponseClick_Click(object sender, RoutedEventArgs e)
        {
            FaqSecretary page = new FaqSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
        }

        public string FaqResponse
        {
            get { return faqResponse; }
            set
            {
                if (faqResponse != value)
                {
                    faqResponse = value;
                    OnPropertyChanged("FaqResponse");
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
