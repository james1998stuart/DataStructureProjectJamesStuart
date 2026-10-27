using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProjectJamesStuart
{
    public class RandomStudy
    {

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
