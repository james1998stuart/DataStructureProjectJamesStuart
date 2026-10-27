using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataStructureProjectJamesStuart
{
    /// <summary>
    /// Loads flashcard information from a structured text file
    /// and converts it into a collection of IFlashcard objects.
    /// </summary>
    public class FlashcardLoader
    {
        /// <summary>
        /// Reads a text file and creates flashcard objects from its contents.
        /// Flashcards are separated by semicolon delimiters.
        /// </summary>
        /// <param name="filePath">
        /// The path to the text file containing the flashcards.
        /// </param>
        /// <returns>
        /// A list containing the flashcards successfully loaded.
        /// </returns>
        public List<IFlashcard> LoadCards(string filePath)
        {
            List<IFlashcard> flashcards = new List<IFlashcard>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                List<string> cardData = new List<string>();
                foreach (string line in lines)
                { 
                    string trimmedLine = line.Trim();

                    if (trimmedLine == ";")
                    {
                        if (cardData.Count == 3)
                        {
                            string prompt = cardData[0];
                            string answer = cardData[1];
                            //Difficulty difficulty = Enum.Parse<Difficulty>(cardData[2], true);
                            if(!Enum.TryParse(cardData[2], true, out Difficulty difficulty))
                            {
                                Console.WriteLine($"Invalid difficulty level: {cardData[2]}. Defaulting to Easy.");
                                difficulty = Difficulty.Easy;
                            }
                            IFlashcard flashcard = new Flashcard(prompt, answer, difficulty);
                            flashcards.Add(flashcard);
                        }
                        cardData.Clear();
                    }
                    else
                    {
                        cardData.Add(trimmedLine);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading flashcards: {ex.Message}");
            }
            return flashcards;
        }   
    }
}
