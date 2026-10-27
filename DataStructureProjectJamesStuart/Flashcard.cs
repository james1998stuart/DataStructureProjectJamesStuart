using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructureProjectJamesStuart;
namespace DataStructureProjectJamesStuart
{
    /// <summary>
    /// Represents a flashcard containing a prompt, answer,
    /// and difficulty level. Implements the IFlashcard interface.
    /// </summary>
    public class Flashcard : IFlashcard
    {
        /// <summary>
        /// Gets the question displayed to the user.
        /// </summary>
        public string Prompt { get;}
        /// <summary>
        /// Gets the correct answer to the flashcard.
        /// </summary>
        public string Answer { get;  }
        /// <summary>
        /// Gets the difficulty level of the flashcard.
        /// </summary>
        public Difficulty Difficulty { get; }

        /// <summary>
        /// Creates a new flashcard with the specified information.
        /// </summary>
        /// <param name="prompt">The question to display.</param>
        /// <param name="answer">The correct answer.</param>
        /// <param name="difficulty">The card's difficulty level.</param>
        public Flashcard(string prompt, string answer, Difficulty difficulty)
        {
            Prompt = prompt;
            Answer = answer;
            Difficulty = difficulty;
        }
    }
}
