using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Trees;

namespace TreesTest
{
    [TestFixture]
    class DnaSequenceTest
    {
        [Test]
        public void TestSequencePrinting()
        {
            DnaSequence dnaSequence = new DnaSequence("AACCGTCT");
            Assert.AreEqual("AACCGTCT", dnaSequence.PrintSequence());
        }

        [Test]
        public void TestImplicitSequenceConvertion()
        {
            DnaSequence dnaSequence = new DnaSequence("AACCGTCT");
            string dnaSequenceAsString = dnaSequence;
            Assert.AreEqual("AACCGTCT", dnaSequenceAsString);
        }

        [Test]
        public void TestImplicitConvertionFromString()
        {
            string dnaSequenceAsString = "AACCGGTGA";
            DnaSequence dnaSequence = dnaSequenceAsString;
            Assert.AreEqual(dnaSequenceAsString, dnaSequence.PrintSequence());
        }

        [Test]
        public void TestDnaSequenceCreationFromInitializer()
        {
            DnaSequence dnaSequence = new DnaSequence() {"A", "C", "C", "T"};
            Assert.AreEqual("ACCT", dnaSequence.PrintSequence());
        }

        [Test]
        public void TestIteratingOverDnaSequence()
        {
            string dnaSequenceAsString = "AGCTAAGG";
            int iterator = 0;
            DnaSequence dnaSequence = new DnaSequence(dnaSequenceAsString);
            foreach (DnaBase dnaBase in dnaSequence)
            {
                Assert.AreEqual(dnaSequenceAsString.ElementAt(iterator), (char)dnaBase);
                iterator++;
            }
        }
    }
}
