namespace DataStructureProjectJamesStuart
{
    using System.Diagnostics;
    using System.IO;
    using DataStructureProjectJamesStuart;
    /// <summary>
    /// Provides the main entry point and menu for the
    /// Flashcard Study Application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Initializes the study modes, accepts the flashcard file path,
        /// and displays the interactive menu used to select a study mode.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments supplied when starting the program.
        /// </param>
        static void Main(string[] args)
        {
            
            FlashcardLoader loader = new FlashcardLoader();
            StackStudy stackStudy = new StackStudy();
            QueueStudy queueStudy = new QueueStudy();
            PriorityStudy priorityStudy = new PriorityStudy();
            RandomStudy randomStudy = new RandomStudy();
            DoomReward doomReward = new DoomReward();

            Console.WriteLine("Welcome to the Flashcard Study Program!");
            Console.WriteLine("What is the file path of your flashcards? Please remove the quotes around the path.");
            string filePath = Console.ReadLine();
            List<IFlashcard> flashcards = loader.LoadCards(filePath);
            while (true)
            {
                Console.WriteLine("Choose a study method:");
                Console.WriteLine("1. Stack Study");
                Console.WriteLine("2. Queue Study");
                Console.WriteLine("3. Priority Study");
                Console.WriteLine("4. Random Study");
                Console.WriteLine("5. ???");
                Console.WriteLine("n. Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        stackStudy.Run(flashcards);
                        break;
                    case "2":
                        queueStudy.Run(flashcards);
                        break;
                    case "3":
                        priorityStudy.Run(flashcards);
                        break;
                    case "4":
                        randomStudy.Run(flashcards);
                        break;
                    case "5":
                        doomReward.launchDoom();
                        return;
                    case "n":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }






        }
    }
}
