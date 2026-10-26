using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructureProjectJamesStuart;
namespace DataStructureProjectJamesStuart
{
    public class Flashcard : IFlashcard
    {
        public string Prompt { get;}
        public string Answer { get;  }
        public Difficulty Difficulty { get; }

        public Flashcard(string prompt, string answer, Difficulty difficulty)
        {
            Prompt = prompt;
            Answer = answer;
            Difficulty = difficulty;
        }
    }
}
