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
    class EvolutionModelTest
    {
        private static int numberOfInterations = 50;

        [Test]
        public void TestBoundaryConditions()
        {
            EvolutionModel model = new EvolutionModel(0, 0);
            DnaBase startBase = DnaBase.G;
            DnaBase evolvedBase;
            for(int i = 0; i < numberOfInterations; i++)
            {
                evolvedBase = model.GenerateNextBase(startBase, i);
                Assert.AreEqual((int)startBase, (int)evolvedBase);
            }
        }
    }
}
