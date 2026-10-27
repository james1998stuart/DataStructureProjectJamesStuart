namespace DataStructureProjectJamesStuart
{
    using DataStructureProjectJamesStuart;
    public class Program
    {
        static void Main(string[] args)
        {
            //connect ze flashcard loader to my main
            FlashcardLoader loader = new FlashcardLoader();
            StackStudy stackStudy = new StackStudy();
            stackStudy.Run(loader.LoadCards("cards.txt"));
           
            /*List<IFlashcard> flashcards = loader.LoadCards("cards.txt");
            foreach (IFlashcard flashcard in flashcards)
            {
                Console.WriteLine($"Prompt: {flashcard.Prompt}");
                Console.WriteLine($"Answer: {flashcard.Answer}");
                Console.WriteLine($"Difficulty: {((Flashcard)flashcard).Difficulty}");
                Console.WriteLine();
            }



            IFlashcard card = new Flashcard("What is the capital of France?", "Paris", Difficulty.Easy);

            Console.WriteLine($"Prompt: {card.Prompt}");
            Console.WriteLine($"Answer: {card.Answer}");
            Console.WriteLine($"Difficulty: {((Flashcard)card).Difficulty}");
            */
            QueueStudy queueStudy = new QueueStudy();
            queueStudy.Run(loader.LoadCards("cards.txt"));



        }
    }
}
