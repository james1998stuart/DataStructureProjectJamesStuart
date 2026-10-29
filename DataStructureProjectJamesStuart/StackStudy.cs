using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProjectJamesStuart
{
    /// <summary>
    /// Implements the Stack (LIFO) flashcard review mode.
    /// Flashcards are reviewed in reverse order of insertion.
    /// </summary>
    public class StackStudy
    {

        /// <summary>
        /// Runs a flashcard study session using a Stack.
        /// Tracks correct answers, incorrect answers, and review order.
        /// </summary>
        /// <param name="flashcards">
        /// The collection of flashcards loaded from the text file.
        /// </param>
        public void Run(List<IFlashcard> flashcards)
        {

            Console.WriteLine("\n\n---------------------------------\n-     initiating stack study    -\n---------------------------------\n\n\n");
            Console.WriteLine("Quit at any time by typing n.\n\n\n");
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
                    reviewOrder.Add($"[{cardposition}] {currentCard.Prompt} - {currentCard.Difficulty}");//Creates a beautiful review order list for the summary at the end of the session
                string userAnswer = Console.ReadLine();
                    if (userAnswer.Equals(currentCard.Answer, StringComparison.OrdinalIgnoreCase))
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
                        Console.WriteLine($"Incorrect. The correct answer is: {currentCard.Answer}");
                        incorrect++;
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
