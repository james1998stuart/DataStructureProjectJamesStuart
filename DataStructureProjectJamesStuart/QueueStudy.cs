using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProjectJamesStuart
{
    /// <summary>
    /// Implements the Queue study mode using FIFO
    /// (First In, First Out) ordering.
    /// </summary>
    public class QueueStudy
    {
        /// <summary>
        /// Reviews flashcards in their original insertion order.
        /// Tracks correct answers, incorrect answers, and review order.
        /// </summary>
        /// <param name="flashcards">
        /// The collection of flashcards to review.
        /// </param>
        public void Run(List<IFlashcard> flashcards)
        {
            Console.WriteLine("\n\n---------------------------------\n-     initiating queue study    -\n---------------------------------\n\n\n");
            Console.WriteLine("Quit at any time by typing n.\n\n\n");
            Queue<IFlashcard> queue = new Queue<IFlashcard>();
            foreach(IFlashcard card in flashcards) {//copying cards over to queue
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

                if (userAnswer.Equals(currentCard.Answer, StringComparison.OrdinalIgnoreCase))//correct case
                {
                    Console.WriteLine("Correct!");
                    correct++;
                }
                else if (userAnswer.Equals("n", StringComparison.OrdinalIgnoreCase))//if user types n they go back to the menu
                {
                    Console.WriteLine("Exiting the study session.");
                    break;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is: {currentCard.Answer}");//incorrect case
                    incorrect++;
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
