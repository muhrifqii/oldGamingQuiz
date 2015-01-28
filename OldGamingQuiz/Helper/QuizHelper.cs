using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OldGamingQuiz.Helper
{
    class QuizHelper
    {
        private IOHelper _io;
        public Profile Profile;
        public QuizHelper()
        {
            _io = new IOHelper();
            string profileTmp = _io.Read("profile.json");
            try
            {
                Profile = JsonConvert.DeserializeObject<Profile>(profileTmp);
            }
            catch (Exception)
            {
                Profile = new Profile()
                {
                    SolvedCount = 0,
                    SolvedQuizes = new List<string>(),
                    QuizContent = new QuizContent(),
                };
            }

        }

        public void solved(Quiz quiz)
        {
            if (Profile == null)
                System.Diagnostics.Debug.WriteLine("Variable Profile ERROR");


            System.Diagnostics.Debug.WriteLine("BERHASIL");
            Profile.SolvedQuizes.Add(quiz.ResourceFile);
            Profile.SolvedCount += 1;
            _io.Write("profile.json", JsonConvert.SerializeObject(Profile));
        }

        public string getProfileString()
        {
            return JsonConvert.SerializeObject(Profile);
        }


        public bool isSolved(Quiz quiz)
        {
            bool ans = false;
            foreach (string item in Profile.SolvedQuizes)
            {
                if (quiz.ResourceFile.Equals(item))
                {
                    ans = true;
                    break;
                }
            }
            return ans;
        }
    }
}
