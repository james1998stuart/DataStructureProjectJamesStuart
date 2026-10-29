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
        public void Run(List<IFlashcard> untouchableList)
        {
            Random rand = new Random();
            //My program removes cards from the list as to not repeat them, so I created a new list to use for random selection.
            List<IFlashcard> flashcards = new List<IFlashcard>(untouchableList);


            Console.WriteLine("\n\n---------------------------------\n-     initiating random study   -\n---------------------------------\n\n\n");
            Console.WriteLine("Quit at any time by typing n.\n\n\n");
            List<string> reviewOrder = new List<string>();
            int correct = 0;
            int incorrect = 0;
            int cardPosition = 1;
            while (flashcards.Count > 0) {
                int currentCard = rand.Next(flashcards.Count);//generates a random index to select a flashcard from the list


                reviewOrder.Add($"[{cardPosition}] {flashcards[currentCard].Prompt} - {flashcards[currentCard].Difficulty}");
                cardPosition++;

                Console.WriteLine($"Prompt: {flashcards[currentCard].Prompt}");
                string userAnswer = Console.ReadLine();

                if (userAnswer.Equals(flashcards[currentCard].Answer, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Correct!");
                    correct++;
                }
                else if(userAnswer.Equals("n", StringComparison.OrdinalIgnoreCase))//if user types n they go back to the menu
                {
                    Console.WriteLine("Exiting the study session.");
                    break;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is: {flashcards[currentCard].Answer}");
                    incorrect++;
                }
                flashcards.RemoveAt(currentCard);//deletes the card so it won't be used again
            }
            int totalReviewed = correct + incorrect;
            Console.WriteLine($"\n\n\nSUMMARY | Mode: Random | Reviewed: {totalReviewed} | " +
                $"Correct: {correct} | Incorrect: {incorrect} | " +
                $"Order: [{string.Join(", ", reviewOrder)}]\n\n\n\n\n");


        }
    }
}
