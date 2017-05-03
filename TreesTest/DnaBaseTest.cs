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
    public class DnaBaseTest
    {
        [Test]
        public void TestConvertionToString()
        {
            DnaBase dnaBase = new DnaBase(DnaBase.DnaBaseEnumeration.A);
            string dnaStringRepresentation = dnaBase.ToString();
            Assert.AreEqual(dnaStringRepresentation, "A");
        }

        [Test]
        public void TestImplicitStringConvertion()
        {
            DnaBase dnaBase = new DnaBase(DnaBase.DnaBaseEnumeration.A);
            string dnaStringRepresentation = dnaBase;
            Assert.AreEqual(dnaStringRepresentation, "A");
        }

        [Test]
        public void TestImplicitIntConvertion()
        {
            DnaBase dnaBase = new DnaBase(DnaBase.DnaBaseEnumeration.G);
            int dnaBaseAsInt = dnaBase;
            Assert.AreEqual(dnaBaseAsInt, (int)DnaBase.DnaBaseEnumeration.G);
        }

        [Test]
        public void TestImplicitConvertionFromInt()
        {
            DnaBase dnaBase = 1;
            Assert.AreEqual((string)dnaBase, "C");
        }

        [Test]
        public void TestImplicitConvertionFromString()
        {
            DnaBase dnaBase = "A";
            Assert.AreEqual((int)DnaBase.A, (int)dnaBase);
            dnaBase = "C";
            Assert.AreEqual((int)DnaBase.C, (int)dnaBase);
            dnaBase = "G";
            Assert.AreEqual((int)DnaBase.G, (int)dnaBase);
            dnaBase = "T";
            Assert.AreEqual((int)DnaBase.T, (int)dnaBase);
        }

        [Test]
        public void TestImplicitConvertionFromChar()
        {
            DnaBase dnaBase = 'A';
            Assert.AreEqual((int)DnaBase.A, (int)dnaBase);
            dnaBase = 'C';
            Assert.AreEqual((int)DnaBase.C, (int)dnaBase);
            dnaBase = 'G';
            Assert.AreEqual((int)DnaBase.G, (int)dnaBase);
            dnaBase = 'T';
            Assert.AreEqual((int)DnaBase.T, (int)dnaBase);
        }

        [Test]
        public void TestStaticMembers()
        {
            int dnaBaseAsInt = DnaBase.A;
            string dnaBaseAsString = DnaBase.A;
            Assert.AreEqual(dnaBaseAsInt, (int)DnaBase.DnaBaseEnumeration.A);
            Assert.AreEqual(dnaBaseAsString, "A");

            dnaBaseAsInt = DnaBase.C;
            dnaBaseAsString = DnaBase.C;
            Assert.AreEqual(dnaBaseAsInt, (int)DnaBase.DnaBaseEnumeration.C);
            Assert.AreEqual(dnaBaseAsString, "C");

            dnaBaseAsInt = DnaBase.G;
            dnaBaseAsString = DnaBase.G;
            Assert.AreEqual(dnaBaseAsInt, (int)DnaBase.DnaBaseEnumeration.G);
            Assert.AreEqual(dnaBaseAsString, "G");

            dnaBaseAsInt = DnaBase.T;
            dnaBaseAsString = DnaBase.T;
            Assert.AreEqual(dnaBaseAsInt, (int)DnaBase.DnaBaseEnumeration.T);
            Assert.AreEqual(dnaBaseAsString, "T");

        }
    }
}
