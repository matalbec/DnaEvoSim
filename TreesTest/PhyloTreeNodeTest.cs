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
            DnaSequence dnaSequence = new DnaSequence(dnaSeqAsString);
            PhyloTreeNode node = new PhyloTreeNode(dnaSequence);
            Assert.AreEqual(dnaSeqAsString, (string)node.GetNodeSequence());
        }
    }
}
