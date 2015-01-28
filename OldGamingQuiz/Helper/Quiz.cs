using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldGamingQuiz.Helper
{
    class Quiz
    {
        public int Id { set; get; }
        public string ResourceFile { set; get; }
        public string Answer { set; get; }
        public Boolean IsSolved { set; get; }
        public string CheckFile { set; get; }
    }
}
