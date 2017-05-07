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

        public PhyloTree(DnaSequence rootDnaSequence, DnaSequenceEvolver evolver, ExponentialDistribution exp, NodeEvolutionScheduler scheduler)
        {
            this.rootNode = new PhyloTreeNode(rootDnaSequence, evolver, exp, scheduler);
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
