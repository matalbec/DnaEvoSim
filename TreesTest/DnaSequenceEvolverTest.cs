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
    class DnaSequenceEvolverTest
    {
        [OneTimeSetUp]
        public void TestSetup()
        {
            EvolutionModel kimuraModel = new EvolutionModel(0.1, 0.3);
            DnaSequenceEvolver.SetupEvolver(kimuraModel);
        }

        [Test]
        public void TestEvolution()
        {
            DnaSequence dnaSequence = new DnaSequence("AAA");
            DnaSequence evolvedSequence = DnaSequenceEvolver.evolver.Evolve(dnaSequence, 1);
            Assert.AreEqual(dnaSequence.Size(), evolvedSequence.Size());
        }
    }
}
