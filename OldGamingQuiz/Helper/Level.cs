using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldGamingQuiz.Helper
{
    class Level
    {
        public string Key { set; get; }
        public string LevelName { get; set; }
        public List<Quiz> Quizes { set; get; }
    }
}
