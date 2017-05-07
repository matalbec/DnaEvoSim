using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Trees
{
    class Program
    {

        private static NodeEvolutionScheduler scheduler;
        private static PhyloTree tree;
        private static Timer evolutionTimer;

        static void Main(string[] args)
        {
            string userInputSequence = string.Empty;
            double alpha = 0;
            double beta = 0;
            double evolutionTime = 0;
            double meanValue = 0;

            Console.WriteLine("Please input root sequence:");
            userInputSequence = Console.ReadLine();
            Console.WriteLine("Alpha paramter for kimura model:");
            alpha = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Beta paramter for kimura model:");
            beta = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Specify evolution time:");
            evolutionTime = Convert.ToDouble(Console.ReadLine());
            evolutionTime = evolutionTime * 1000;
            Console.WriteLine("Specify mean value for exponential distribution");
            meanValue = Convert.ToDouble(Console.ReadLine());


            ExponentialDistribution expDistribution = new ExponentialDistribution(meanValue);
            EvolutionModel kimuraModel = new EvolutionModel(alpha, beta);
            DnaSequence userSequence = new DnaSequence(userInputSequence);
            DnaSequenceEvolver sequenceEvolver = new DnaSequenceEvolver(kimuraModel);
            NodeEvolutionScheduler scheduler = new NodeEvolutionScheduler(evolutionTime);
            Program.scheduler = scheduler;
            PhyloTree tree = new PhyloTree(userSequence, sequenceEvolver, expDistribution, scheduler);
            Program.tree = tree;
            Program.evolutionTimer = new Timer(evolutionTime);
            Program.evolutionTimer.Elapsed += new ElapsedEventHandler(Program.EvolutionEndCallback);
            Program.evolutionTimer.AutoReset = false;
            Program.evolutionTimer.Enabled = true;
            Console.ReadLine();
        }

        static void EvolutionEndCallback(object sender, ElapsedEventArgs args)
        {
            Program.scheduler.StopScheduler();
            Console.WriteLine("Printing Tree:");
            Console.WriteLine(Program.tree.PrintTree());
        }

    }
}
