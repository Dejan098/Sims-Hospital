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

namespace Hospital.ViewSecretary
{
    /// <summary>
    /// Interaction logic for FaqSecretary.xaml
    /// </summary>
    public partial class FaqSecretary : Page
    {
        private Staff loggedInStaff;
        private readonly FaqController _faqController;
        private ObservableCollection<Faq> faqs;
        private Faq selectedFaq;

        public FaqSecretary(Staff staff)
        {
            InitializeComponent();
            this.DataContext = this;
            loggedInStaff = staff;

            var app = Application.Current as App;
            _faqController = app.FaqController;

            GetAllFaq();
            DataGrid_Questions.ItemsSource = faqs;
        }

        private void GetAllFaq()
        {
            faqs = new ObservableCollection<Faq>(_faqController.getAllFaqsNotAnswered().ToList());
        }

        private void RespondButton_Click(object sender, RoutedEventArgs e)
        {
            selectedFaq = (Faq)DataGrid_Questions.SelectedItem;
            FaqAnswerSecretary page = new FaqAnswerSecretary(loggedInStaff, selectedFaq);
            this.NavigationService.Navigate(page);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Faq selectedFaq = (Faq)DataGrid_Questions.SelectedItem;
            _faqController.Delete(selectedFaq);

            FaqSecretary page = new FaqSecretary(loggedInStaff);
            this.NavigationService.Navigate(page);
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
    }
}
