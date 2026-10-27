namespace DataStructureProjectJamesStuart
{
    using System.Diagnostics;
    using System.IO;
    using DataStructureProjectJamesStuart;
    public class Program
    {
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
            while (true)
            {
                Console.WriteLine("Choose a study method:");
                Console.WriteLine("1. Stack Study");
                Console.WriteLine("2. Queue Study");
                Console.WriteLine("3. Priority Study");
                Console.WriteLine("4. Random Study");
                Console.WriteLine("5. ???");
                Console.WriteLine("6. Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        stackStudy.Run(loader.LoadCards(filePath));
                        break;
                    case "2":
                        queueStudy.Run(loader.LoadCards(filePath));
                        break;
                    case "3":
                        priorityStudy.Run(loader.LoadCards(filePath));
                        break;
                    case "4":
                        randomStudy.Run(loader.LoadCards(filePath));
                        break;
                    case "5":
                        doomReward.launchDoom();
                        return;
                    case "6":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }









            
            //randomStudy.Run(loader.LoadCards("cards.txt"));
            //priorityStudy.Run(loader.LoadCards("cards.txt"));
            //stackStudy.Run(loader.LoadCards("cards.txt"));
            //queueStudy.Run(loader.LoadCards("cards.txt"));







        }
    }
}
