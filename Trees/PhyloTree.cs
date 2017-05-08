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

        public PhyloTree(DnaSequence rootDnaSequence)
        {
            this.rootNode = new PhyloTreeNode(rootDnaSequence);
        }

        private string PrintTreeRecursive(PhyloTreeNode node, int depthLevel)
        {
            string partialString = new string(' ', depthLevel);
            List<PhyloTreeNode> children = node.GetChildrenNodes();
            partialString += $"-{node.GetNodeSequence()}\n";
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
