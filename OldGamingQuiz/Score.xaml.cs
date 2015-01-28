using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using OldGamingQuiz.Helper;
using Newtonsoft.Json;

namespace OldGamingQuiz
{
    public partial class Score : PhoneApplicationPage
    {
        public Score()
        {
            InitializeComponent();
            var iso = new IOHelper();
            Profile profil = JsonConvert.DeserializeObject<Profile>(iso.Read("profile.json"));
            solved.Text = profil.SolvedQuizes.Count().ToString();
            unsolved.Text = (36 - profil.SolvedQuizes.Count()).ToString();
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            //ShareStatusTask shareStatusTask = new ShareStatusTask();
            //shareStatusTask.Status = "Look, I've just solved " + solved.Text + " screenshot puzzles in Old Gaming Quiz";
            //shareStatusTask.Show();

            ShareLinkTask shareLinkTask = new ShareLinkTask();

            shareLinkTask.Title = "Look, I've just solved " + solved.Text + " screenshot puzzles in Old Gaming Quiz";
            shareLinkTask.LinkUri = new Uri("http://twitter.com/muhrifqii", UriKind.Absolute);
            shareLinkTask.Message = "Look I've just solved " + solved.Text + " screenshot puzzles in Old Gaming Quiz";

            shareLinkTask.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IOHelper io = new IOHelper();
            string profile = io.Read("profile.json");
            io.Write("profile.json", JsonConvert.SerializeObject(new Profile()
            {   
                QuizContent = new QuizContent(),
                SolvedCount = 0,
                SolvedQuizes = new List<string>()
            }));

            this.NavigationService.GoBack();
        }
    }
}