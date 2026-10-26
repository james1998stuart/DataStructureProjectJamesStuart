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
            while(queue.Count > 0)
            {
                IFlashcard currentCard = queue.Dequeue();
                Console.WriteLine($"Prompt: {currentCard.Prompt}");
                string userAnswer = Console.ReadLine();
                if (userAnswer.Equals(currentCard.Answer, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is: {currentCard.Answer}");
                }
            }
        }
    }
}
