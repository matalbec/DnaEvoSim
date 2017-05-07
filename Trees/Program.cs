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
            PhyloTree tree = new PhyloTree(userSequence, sequenceEvolver, expDistribution, scheduler);

            System.Threading.Thread.Sleep(10000);
            Console.WriteLine("Attemtping to print tree");
            Console.WriteLine(tree.PrintTree());
            while (true)
            {

            }

        }

    }
}
