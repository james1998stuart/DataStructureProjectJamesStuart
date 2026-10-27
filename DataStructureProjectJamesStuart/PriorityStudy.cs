using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProjectJamesStuart
{
    public class PriorityStudy
    {
        public void Run(List<IFlashcard> flashcards)
        {
            Console.WriteLine("\n\n---------------------------------\n-   initiating priority study   -\n---------------------------------\n\n\n");
            PriorityQueue<IFlashcard, Difficulty> priorityQueue = new PriorityQueue<IFlashcard, Difficulty>();
            int correct = 0;
            int incorrect = 0;
            int cardPosition = 0;
            List<string> reviewOrder = new List<string>();
            foreach (Flashcard card in flashcards)
            {
                priorityQueue.Enqueue(card, card.Difficulty);
            }
            while (priorityQueue.Count > 0)
            {
                IFlashcard currentCard = priorityQueue.Dequeue();
                cardPosition++;
                reviewOrder.Add($"[{cardPosition}] {currentCard.Prompt} - {currentCard.Difficulty}");
                Console.WriteLine($"[{currentCard.Difficulty}]\nPrompt: {currentCard.Prompt}");
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
                if(priorityQueue.Count > 0)
                {
                    Console.WriteLine("\nPress Enter to continue or n to quit: \n");  
                    string choice = Console.ReadLine();
                    if (choice.Equals("n", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                }

            }
            int totalReviewed = correct + incorrect;

            Console.WriteLine($"\n\n\nSUMMARY | Mode: Priority Queue | Reviewed: {totalReviewed} | " +
                $"Correct: {correct} | Incorrect: {incorrect} | " +
                $"Order: [{string.Join(", ", reviewOrder)}]\n\n\n\n\n");

        }
    }
}
