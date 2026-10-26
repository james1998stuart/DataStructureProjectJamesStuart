using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProjectJamesStuart
{
    public class QueueStudy
    {
        public void Run(List<IFlashcard> flashcards)
        {
            Queue<IFlashcard> queue = new Queue<IFlashcard>();
            foreach(IFlashcard card in flashcards) {
                queue.Enqueue(card);
            }
            int correct = 0;
            int incorrect = 0;
            List<string> reviewOrder = new List<string>();

            while (queue.Count > 0)
            {
                
                IFlashcard currentCard = queue.Dequeue();
                reviewOrder.Add($"{currentCard.Prompt} - {currentCard.Difficulty}");
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
            }
            int totalReviewed = correct + incorrect;
            Console.WriteLine("\nSession Summary");
            Console.WriteLine($"Total Reviewed: { totalReviewed}");
            Console.WriteLine($"Correct: {correct}");   
            Console.WriteLine($"Incorrect: {incorrect}");

            Console.WriteLine($"Order: [{string.Join(", ", reviewOrder)}]");

        }
    }
}
