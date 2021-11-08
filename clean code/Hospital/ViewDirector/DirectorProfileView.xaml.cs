using Hospital.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DirectorProfileView.xaml
    /// </summary>
    public partial class DirectorProfileView : Page
    {
        public Staff director;
        public DirectorProfileView()
        {
            InitializeComponent();
        }

        public DirectorProfileView(Staff dir)
        {
            InitializeComponent();
            director = dir;
            nameDirector.Text = director.Name;
            lastnameDirector.Text = director.Surname;
            username.Text = director.Username;
        }
    }
}
