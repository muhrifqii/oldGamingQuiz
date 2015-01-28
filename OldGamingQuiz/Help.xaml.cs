using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OldGamingQuiz.Helper;

namespace OldGamingQuiz
{
    public partial class Help : PhoneApplicationPage
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("there will be a message telling that wether your anwer is correct or not","Answer is dynasty warrior",MessageBoxButton.OK);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("there will be a message telling that wether your anwer is correct or not", "Answer is kabuterimon", MessageBoxButton.OK);

        }
    }
}