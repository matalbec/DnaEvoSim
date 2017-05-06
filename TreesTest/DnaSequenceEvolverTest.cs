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
        [Test]
        public void TestEvolution()
        {
            EvolutionModel kimuraModel = new EvolutionModel(0.1, 0.3);
            DnaSequenceEvolver evolver = new DnaSequenceEvolver(kimuraModel);
            DnaSequence dnaSequence = new DnaSequence("AAA");
            DnaSequence evolvedSequence = evolver.Evolve(dnaSequence, 1);
            Assert.AreEqual(dnaSequence.Size(), evolvedSequence.Size());
        }
    }
}
