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
                List<PhyloTreeNode> evolvedChildren = new List<PhyloTreeNode>() {
                    new PhyloTreeNode(evolvedSequence1),
                    new PhyloTreeNode(evolvedSequence2)
                };
                node.AppendChildren(evolvedChildren);
                newGeneration.AddRange(evolvedChildren);
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

        private string PrintTreeRecursive(PhyloTreeNode node, int depthLevel)
        {
            string partialString = string.Empty;
            List<PhyloTreeNode> children = node.GetChildrenNodes();
            for (int i = 0; i < depthLevel; i++)
            {
                partialString += "-";
            }
            partialString += node.GetNodeSequence();
            partialString += "\n";
            foreach (var childNode in children)
            {
                partialString += this.PrintTreeRecursive(childNode, depthLevel + 1);
            }
            return partialString;
        }

        public string PrintTree()
        {
            return this.PrintTreeRecursive(this.rootNode, 0);
        }

    }
}
