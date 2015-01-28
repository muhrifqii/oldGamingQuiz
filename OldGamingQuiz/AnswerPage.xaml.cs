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
using System.Windows.Media.Imaging;

namespace OldGamingQuiz
{
    public partial class AnswerPage : PhoneApplicationPage
    {
        private Level level;
        private string level_name = "";
        private string id;
        private QuizContent quizContent;
        private Quiz quiz;
        private string answer = "";

        public AnswerPage()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                quizContent = new QuizContent();
                level = quizContent.GetLevel(level_name);
                level_text.Text = level.LevelName;
                
                quiz = level.Quizes[int.Parse(id)-1];
                answer = quiz.Answer;
                guess_image.Source = new BitmapImage(new Uri(quiz.ResourceFile, UriKind.Relative));
            };
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NavigationContext.QueryString.TryGetValue("level", out level_name);
            NavigationContext.QueryString.TryGetValue("id", out id);
            //if (NavigationContext.QueryString.TryGetValue("level", out level_name))
            //{
            //    loadPage();
            //}
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string tmpAnswer = answerBox.Text.ToLower();
            if(tmpAnswer.Equals(answer))
            {
                QuizHelper qh = new QuizHelper();
                qh.solved(quiz);
                MessageBox.Show("Success, Your answer is true!");
                NavigationService.GoBack();
            }
            else{
                MessageBox.Show("Sorry, your answer apparently wrong");
            }
        }
    }
}