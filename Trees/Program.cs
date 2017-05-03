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

            userInputSequence = Console.ReadLine();
            alpha = Convert.ToDouble(Console.ReadLine());
            beta = Convert.ToDouble(Console.ReadLine());

            EvolutionModel kimuraModel = new EvolutionModel(alpha, beta);
            DnaSequence userSequence = new DnaSequence(userInputSequence);
            DnaSequenceEvolver sequenceEvolver = new DnaSequenceEvolver(kimuraModel);
            PhyloTreeNode rootNode = new PhyloTreeNode(userSequence);
            PhyloTree tree = new PhyloTree(rootNode, sequenceEvolver);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Printing generation at time t= {0}\n{1}",i, tree.PrintCurrentGenerationSequences());
                tree.EvolveAllChildren(i);
            }
            while (true)
            {

            }
        }
    }
}
