using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Specify mean value for exponential distribution");
            meanValue = Convert.ToDouble(Console.ReadLine());


            ExponentialDistribution expDistribution = new ExponentialDistribution(meanValue);
            Random rnd = new Random();
            Console.WriteLine("Exponential");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Got number: {0}", expDistribution.NextDouble());
            }
            Console.WriteLine("Uniform");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Got number: {0}", rnd.NextDouble());
            }
            EvolutionModel kimuraModel = new EvolutionModel(alpha, beta);
            DnaSequence userSequence = new DnaSequence(userInputSequence);
            DnaSequenceEvolver sequenceEvolver = new DnaSequenceEvolver(kimuraModel);
            PhyloTreeNode rootNode = new PhyloTreeNode(userSequence);
            PhyloTree tree = new PhyloTree(rootNode, sequenceEvolver);
            for (int i = 0; i < 5; i++)
            {
                tree.EvolveAllChildren(i);
            }
            while (true)
            {

            }
        }
    }
}
