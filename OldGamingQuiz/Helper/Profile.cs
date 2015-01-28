using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldGamingQuiz.Helper
{
    class Profile
    {
        public List<string> SolvedQuizes { get; set; }
        public QuizContent QuizContent { get; set; }
        public int SolvedCount { get; set; }
    }
}
