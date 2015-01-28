using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldGamingQuiz.Helper
{
    class QuizContent
    {
        private Level _levelG1, _levelG2;
        private Level _levelN1, _levelN2;

        public QuizContent()
        {
            InitLevelG1();
            InitLevelG2();
            InitLevelN1();
            InitLevelN2();
        }

        public Level GetLevel(string level)
        {
            //lvg1 untuk level1 catch the game
            if (level.Equals("lvg1")) return _levelG1;
            else if (level.Equals("lvg2")) return _levelG2;
            else if (level.Equals("lvn1")) return _levelN1;
            else if (level.Equals("lvn2")) return _levelN2;

            return new Level();
        }

        private void InitLevelG1()
        {
            _levelG1 = new Level();
            _levelG1.Key = "lv1";
            _levelG1.LevelName = "Level 1";
            List<Quiz> tmpQuiz = new List<Quiz>();

            List<string> ans = new List<string>()
            {
                "contra", "crash bandicoot", "ctr", "mario world", "metal slug x", "pepsiman", "resident evil 3 nemesis",
                "road rash", "virtua cop 2", "yu-gi-oh"
            };

            int i = 1;
            foreach (string item in ans)
            {
                tmpQuiz.Add(new Quiz()
                {
                    Id = i,
                    Answer = item,
                    ResourceFile = "Assets/CatchTheGame/Level1/" + item + ".jpg"
                });
                i++;
            }
            _levelG1.Quizes = tmpQuiz;
        }

        private void InitLevelG2()
        {
            _levelG2 = new Level();
            _levelG2.Key = "lvg2";
            _levelG2.LevelName = "Level 2";
            List<Quiz> tmpQuiz = new List<Quiz>();

            List<string> ans = new List<string>()
            {
                "asterix and obelix", "chip's challenge", "final fantasy tactic",
                "metal gear solid", "resident evil 2", "ski free", "soul blade",
                "super shot soccer", "the addams family", "the mask"
            };
            int i = 1;
            foreach (string item in ans)
            {
                tmpQuiz.Add(new Quiz()
                {
                    Id = i,
                    Answer = item,
                    ResourceFile = "Assets/CatchTheGame/Level2/" + item + ".jpg"
                });
                i++;
            }
            _levelG2.Quizes = tmpQuiz;
        }

        public void InitLevelN1()
        {
            _levelN1 = new Level();
            _levelN1.Key = "lvn1";
            _levelN1.LevelName = "Level 1";
            List<Quiz> tmpQuiz = new List<Quiz>();
            List<string> ans = new List<string>()
            {
                "kirby", "kyo", "link", "mario", "megaman", "nemesis", "ryu", "spyro"
            };
            int i = 1;
            foreach (string item in ans)
            {
                tmpQuiz.Add(new Quiz()
                {
                    Id = i,
                    Answer = item,
                    ResourceFile = "Assets/CatchTheName/Level1/" + item + ".jpg"
                });
                i++;
            }
            _levelN1.Quizes = tmpQuiz;
        }

        public void InitLevelN2()
        {
            _levelN2 = new Level();
            _levelN2.Key = "lvn2";
            _levelN2.LevelName = "Level 2";
            List<Quiz> tmpQuiz = new List<Quiz>();
            List<string> ans = new List<string>()
            {
                "abe", "bomberman", "chocobo", "crono", "iori", "lemmings", "raziel", "wednesday"
            };
            int i = 1;
            foreach (string item in ans)
            {
                tmpQuiz.Add(new Quiz()
                {
                    Id = i,
                    Answer = item,
                    ResourceFile = "Assets/CatchTheName/Level2/" + item + ".jpg"
                });
                i++;
            }
            _levelN2.Quizes = tmpQuiz;
        }

    }
}
