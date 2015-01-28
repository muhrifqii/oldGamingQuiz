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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OldGamingQuiz
{
    public partial class CatchTheGame : PhoneApplicationPage
    {
        private Profile _profile;
        public CatchTheGame()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
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
            };
        }

        private void StackPanel_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/LevelPage.xaml?level=lvg1", UriKind.Relative));
        }

        private void StackPanel_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/LevelPage.xaml?level=lvg2", UriKind.Relative));
        }

        private void StackPanel_Tap_3(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("More Levels Will Coming Soon", "Information", MessageBoxButton.OK);
        }
    }
}