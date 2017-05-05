using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class PhyloTreeNode
    {
        private DnaSequence dnaSequence;
        private List<PhyloTreeNode> childrenNodes;

        public PhyloTreeNode(DnaSequence dnaSequence)
        {
            this.dnaSequence = dnaSequence;
            this.childrenNodes = new List<PhyloTreeNode>();
        }

        public DnaSequence GetNodeSequence()
        {
            return this.dnaSequence;
        }

        public void AppendChildren(List<PhyloTreeNode> childNodes)
        {
            this.childrenNodes.AddRange(childNodes);
        }

        public List<PhyloTreeNode> GetChildrenNodes()
        {
            return this.childrenNodes;
        }
    }
}
