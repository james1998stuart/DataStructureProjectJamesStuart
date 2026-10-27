using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProjectJamesStuart
{
    public class QueueStudy
    {
        /// <summary>
        /// Runs a queue-based study session.
        /// </summary>
        /// <param name="flashcards">Cards to review in file order.</param>
        public void Run(List<IFlashcard> flashcards)
        {
            Console.WriteLine("\n\n---------------------------------\n-     initiating queue study    -\n---------------------------------\n\n\n");
            Queue<IFlashcard> queue = new Queue<IFlashcard>();
            foreach(IFlashcard card in flashcards) {
                queue.Enqueue(card);
            }
            int correct = 0;
            int incorrect = 0;
            int cardPosition = 0;
            List<string> reviewOrder = new List<string>();

            while (queue.Count > 0)
            {
                cardPosition++;
                IFlashcard currentCard = queue.Dequeue();
                reviewOrder.Add($"[{cardPosition}] {currentCard.Prompt} - {currentCard.Difficulty}");
                

                Console.WriteLine($"Prompt: {currentCard.Prompt}");
                string userAnswer = Console.ReadLine();
                if (userAnswer.Equals(currentCard.Answer, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Correct!");
                    correct++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is: {currentCard.Answer}");
                    incorrect++;
                }
                if (queue.Count > 0)
                {
                    Console.WriteLine("\nPress Enter to continue or n to quit: ");
                    string choice = Console.ReadLine();
                    if (choice.Equals("n", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                }
            }
            int totalReviewed = correct + incorrect;
            Console.WriteLine(
            $"\n\n\nSUMMARY | Mode: Queue | Reviewed: {totalReviewed} | " +
             $"Correct: {correct} | Incorrect: {incorrect} | " +
              $"Order: [{string.Join(", ", reviewOrder)}]\n\n\n\n\n");

        }
    }
}
