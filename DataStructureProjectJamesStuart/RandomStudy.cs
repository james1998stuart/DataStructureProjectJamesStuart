using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProjectJamesStuart
{
    /// <summary>
    /// Implements random flashcard studying using a generic List
    /// and the built-in Random class.
    /// </summary>
    public class RandomStudy
    {
        /// <summary>
        /// Randomly selects flashcards from the remaining collection.
        /// Reviewed cards are removed to prevent repeated selection
        /// during a completed session.
        /// </summary>
        /// <param name="flashcards">
        /// The collection of flashcards used for random selection.
        /// This list is modified as cards are removed.
        /// </param>
        public void Run(List<IFlashcard> flashcards)
        {
            Random rand = new Random();

            Console.WriteLine("\n\n---------------------------------\n-     initiating random study   -\n---------------------------------\n\n\n");
            List<string> reviewOrder = new List<string>();
            int correct = 0;
            int incorrect = 0;
            int cardPosition = 1;
            while (flashcards.Count > 0) {
                int currentCard = rand.Next(flashcards.Count);
                reviewOrder.Add($"[{cardPosition}] {flashcards[currentCard].Prompt} - {flashcards[currentCard].Difficulty}");
                cardPosition++;
                Console.WriteLine($"Prompt: {flashcards[currentCard].Prompt}");
                string userAnswer = Console.ReadLine();
                if (userAnswer.Equals(flashcards[currentCard].Answer, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Correct!");
                    correct++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is: {flashcards[currentCard].Answer}");
                    incorrect++;
                }
                if (flashcards.Count > 0)
                {
                    Console.WriteLine("\nPress Enter to continue or n to quit: ");
                    string choice = Console.ReadLine();
                    if (choice.Equals("n", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                }
                flashcards.RemoveAt(currentCard);
            }
            int totalReviewed = correct + incorrect;
            Console.WriteLine($"\n\n\nSUMMARY | Mode: Random | Reviewed: {totalReviewed} | " +
                $"Correct: {correct} | Incorrect: {incorrect} | " +
                $"Order: [{string.Join(", ", reviewOrder)}]\n\n\n\n\n");


        }
    }
}
