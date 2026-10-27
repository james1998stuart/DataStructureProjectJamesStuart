using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProjectJamesStuart
{
    /// <summary>
    /// Implements Priority Round-Robin studying by cycling
    /// through Easy, Medium, and Hard difficulty levels.
    /// </summary>
    public class PriorityStudy
    {
        /// <summary>
        /// Separates flashcards into difficulty-based priority queues
        /// and arranges them in a repeating Easy, Medium, Hard sequence.
        /// </summary>
        /// <param name="flashcards">
        /// The collection of flashcards to organize and review.
        /// </param>
        public void Run(List<IFlashcard> flashcards)
        {
            Console.WriteLine("\n\n---------------------------------\n-   initiating priority study   -\n---------------------------------\n\n\n");
            Queue<IFlashcard> priorityQueue = new();
            int correct = 0;
            int incorrect = 0;
            int cardPosition = 0;
            
            List<string> reviewOrder = new List<string>();
            PriorityQueue<IFlashcard, Difficulty> easyQueue = new();
            PriorityQueue<IFlashcard, Difficulty> mediumQueue = new();
            PriorityQueue<IFlashcard, Difficulty> hardQueue = new();
            foreach (Flashcard card in flashcards)
            {
                if (card.Difficulty == Difficulty.Easy)
                {
                    easyQueue.Enqueue(card, card.Difficulty);
                }
                else if (card.Difficulty == Difficulty.Medium)
                {
                    mediumQueue.Enqueue(card, card.Difficulty);
                }
                else if (card.Difficulty == Difficulty.Hard)
                {
                    hardQueue.Enqueue(card, card.Difficulty);
                }
                
            }

            int currentDifficulty = 0;
            while(easyQueue.Count > 0 || mediumQueue.Count > 0 || hardQueue.Count > 0)
            {
                
                if(currentDifficulty == 0)
                {
                    if(easyQueue.Count > 0)
                    {
                        priorityQueue.Enqueue(easyQueue.Dequeue());
                    }                   
                    
                }
                if (currentDifficulty == 1)
                {
                    if (mediumQueue.Count > 0)
                    { 
                        priorityQueue.Enqueue(mediumQueue.Dequeue());
                      }
                    
                }
                if (currentDifficulty == 2)
                {
                    if (hardQueue.Count > 0){
                        priorityQueue.Enqueue(hardQueue.Dequeue());                        
                    }                   
                }

                if (currentDifficulty ==2)
                {
                    currentDifficulty = 0;
                }
                else
                {
                    currentDifficulty++;
                }
                    
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
