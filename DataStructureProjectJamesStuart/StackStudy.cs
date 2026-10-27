using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProjectJamesStuart
{
    public class StackStudy
    {


        public void Run(List<IFlashcard> flashcards)
        {

            Console.WriteLine("\n\n---------------------------------\n-     initiating stack study    -\n---------------------------------\n\n\n");
            Stack<IFlashcard> stack = new Stack<IFlashcard>();

            List<string> reviewOrder = new List<string>();    

            int correct = 0;
            int incorrect = 0;
            int cardposition = 0;

            //adding each flashcard to the stack
            foreach (IFlashcard card in flashcards)
            {
                stack.Push(card);
            }
              while (stack.Count > 0)
                {
                    IFlashcard currentCard = stack.Pop();
                    Console.WriteLine($"Prompt: {currentCard.Prompt}");
                     cardposition++;
                    reviewOrder.Add($"[{cardposition}] {currentCard.Prompt} - {currentCard.Difficulty}");
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

                if (stack.Count > 0)
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
            $"\n\n\nSUMMARY | Mode: Stack | Reviewed: {totalReviewed} | " +
             $"Correct: {correct} | Incorrect: {incorrect} | " +
              $"Order: [{string.Join(", ", reviewOrder)}]\n\n\n\n\n");



        }
    }
}
