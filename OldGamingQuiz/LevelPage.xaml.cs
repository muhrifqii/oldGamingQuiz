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
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace OldGamingQuiz
{
    public partial class LevelPage : PhoneApplicationPage
    {
        private Level _level;
        private string _levelName = "";
        private QuizContent _quizContent;
        private List<bool> _solvedAns;
        public LevelPage()
        {
            InitializeComponent();
            
            Loaded += (s,e) => 
            {
                NavigationContext.QueryString.TryGetValue("level", out _levelName);
                System.Diagnostics.Debug.WriteLine(_levelName);
                _quizContent = new QuizContent();
                _level = _quizContent.GetLevel(_levelName);
                level_text.Text = _level.LevelName;

                _solvedAns = new List<bool>();
                var iso = new IOHelper();
                try
                {
                    // koding untuk flag sudah diselesaikan
                    Profile profil = JsonConvert.DeserializeObject<Profile>(iso.Read("profile.json"));

                    bool result;
                    foreach (Quiz item in _level.Quizes)
                    {
                        result = false;
                        foreach (string item2 in profil.SolvedQuizes)
                        {
                            if (item.ResourceFile.Equals(item2))
                            {
                                result = true;
                                break;
                            }
                        }
                        _solvedAns.Add(result);
                    }

                    // new quiz
                    List<Quiz> quizes = new List<Quiz>();
                    int i = 0;
                    foreach (var item in _level.Quizes)
                    {
                        if (_solvedAns[i])
                        {
                            _level.Quizes[i].IsSolved = true;
                            _level.Quizes[i].CheckFile = "/Images/correct.png";
                        }
                        else
                        {
                            _level.Quizes[i].IsSolved = true;
                            //_level.Quizes[i].CheckFile = "/Assets/trans.png";
                        }
                        i++;
                    }

                    radListBox.ItemsSource = _level.Quizes;
                }
                catch (Exception)
                {
                }

            };
        }

        private void im_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image im = (Image)sender;
        }

        public sealed class ImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType,
                                  object parameter, CultureInfo culture)
            {
                try
                {
                    return new BitmapImage(new Uri((string)value));
                }
                catch
                {
                    return new BitmapImage();
                }
            }

            public object ConvertBack(object value, Type targetType,
                                      object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        private void radListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Quiz quiz = (Quiz)radListBox.SelectedItem;

                int i = 0;
                foreach (Quiz item in radListBox.RealizedItems)
                {
                    if (item.ResourceFile.Equals(quiz.ResourceFile))
                    {
                        break;
                    }
                    i++;
                }

                if (_solvedAns[i])
                {
                    MessageBox.Show("You have already answered this screenshot");
                }
                else
                {
                    NavigationService.Navigate(new Uri("/AnswerPage.xaml?level=" + _levelName + "&id=" + quiz.Id, UriKind.Relative));
                }
            }
            catch (Exception er)
            {
                //MessageBox.Show(er.Message);
            }
        }

    }
}