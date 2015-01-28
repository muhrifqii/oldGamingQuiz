using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using OldGamingQuiz.Helper;
using Newtonsoft.Json;

namespace OldGamingQuiz
{
    public partial class MainPage : PhoneApplicationPage
    {
        FlipTileTemplate _flipTemplate;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                _flipTemplate = new FlipTileTemplate();
                IOHelper io = new IOHelper();
                string profile = io.Read("profile.json");
                if (profile.Equals(""))
                {
                    io.Write("profile.json", JsonConvert.SerializeObject(new Profile()
                    {
                        QuizContent = new QuizContent(),
                        SolvedCount = 0,
                        SolvedQuizes = new List<string>()
                    }));
                    profile = io.Read("profile.json");
                }
                QuizHelper qh = new QuizHelper();
                System.Diagnostics.Debug.WriteLine(qh.getProfileString());
                _flipTemplate.SFlipTileTemplate();
            };

            
            //Shows the rate reminder message, according to the settings of the RateReminder.
            (App.Current as App).rateReminder.Notify();
            
        }

        private void StackPanel_Tap(object sender, GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/CatchTheGame.xaml", UriKind.RelativeOrAbsolute));
        }
            
        private void StackPanel_Tap_1(object sender, GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/CatchTheName.xaml", UriKind.RelativeOrAbsolute));
        }

        private void StackPanel_Tap_2(object sender, GestureEventArgs e)
        {
            MessageBox.Show("We will working on it soon", "Information", MessageBoxButton.OK);
        }

        private void AboutClick(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/About.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ScoreClick(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Score.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Help.xaml", UriKind.RelativeOrAbsolute));
        }

    }
}
