using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class PhyloTree
    {
        private PhyloTreeNode rootNode;
        private List<PhyloTreeNode> currentGeneration;
        private DnaSequenceEvolver evolver;

        public PhyloTree(PhyloTreeNode rootNode, DnaSequenceEvolver evolver)
        {
            this.rootNode = rootNode;
            this.currentGeneration = new List<PhyloTreeNode>() { rootNode };
            this.evolver = evolver;
        }

        public void EvolveAllChildren(double time)
        {
            int numberOfChildren = this.currentGeneration.Count();
            List<PhyloTreeNode> newGeneration = new List<PhyloTreeNode>();
            foreach (PhyloTreeNode node in this.currentGeneration)
            {
                DnaSequence evolvedSequence1 = this.evolver.Evolve(node.GetNodeSequence(), time);
                DnaSequence evolvedSequence2 = this.evolver.Evolve(node.GetNodeSequence(), time);
                newGeneration.Add(new PhyloTreeNode(evolvedSequence1));
                newGeneration.Add(new PhyloTreeNode(evolvedSequence2));
            }
            this.currentGeneration = newGeneration;
        }

        public string PrintCurrentGenerationSequences()
        {
            string currentGenerationSequences = string.Empty;
            foreach(PhyloTreeNode node in this.currentGeneration)
            {
                currentGenerationSequences += ("Sequence: " + node.GetNodeSequence() + "\n");
            }
            return currentGenerationSequences;
        }
    }
}
