using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Trees;
using NUnit.Framework;

namespace TreesTest
{
    [TestFixture]
    class PhyloTreeNodeTest
    {
        [Test]
        public void TestGettingNodeSequence()
        {
            string dnaSeqAsString = "AAGCTTA";
            PhyloTreeNode node = new PhyloTreeNode(dnaSeqAsString);
            Assert.AreEqual(dnaSeqAsString, (string)node.GetNodeSequence());
        }

        [Test]
        public void TestAppendingChildren()
        {
            PhyloTreeNode rootNode = new PhyloTreeNode("AAA");
            List<PhyloTreeNode> children = new List<PhyloTreeNode>()
            {
                new PhyloTreeNode("CCC"),
                new PhyloTreeNode("GGG")
            };
            rootNode.AppendChildren(children);
            List<PhyloTreeNode> appendedChildren = rootNode.GetChildrenNodes();
            Assert.AreEqual(appendedChildren.Count, 2);
            Assert.AreEqual((string)appendedChildren.ElementAt(0).GetNodeSequence(), "CCC");
            Assert.AreEqual((string)appendedChildren.ElementAt(1).GetNodeSequence(), "GGG");
        }
    }
}
