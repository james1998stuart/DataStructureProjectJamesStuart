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
            doomReward.launchDoom();



            randomStudy.Run(loader.LoadCards("cards.txt"));
            randomStudy.Run(loader.LoadCards("cards.txt"));
            randomStudy.Run(loader.LoadCards("cards.txt"));
            randomStudy.Run(loader.LoadCards("cards.txt"));
            //priorityStudy.Run(loader.LoadCards("cards.txt"));
            //stackStudy.Run(loader.LoadCards("cards.txt"));
            //queueStudy.Run(loader.LoadCards("cards.txt"));


            
            



        }
    }
}
