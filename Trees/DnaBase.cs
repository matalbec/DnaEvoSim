using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class DnaBase
    {
        public static DnaBase A = new DnaBase(DnaBaseEnumeration.A);
        public static DnaBase C = new DnaBase(DnaBaseEnumeration.C);
        public static DnaBase G = new DnaBase(DnaBaseEnumeration.G);
        public static DnaBase T = new DnaBase(DnaBaseEnumeration.T);

        public enum DnaBaseEnumeration
        {
            A = 0,
            C = 1,
            G = 2,
            T = 3
        }
        private DnaBaseEnumeration dnaBase;
        private string[] basePairNames = {"A", "C", "G", "T"};

        public DnaBase(DnaBaseEnumeration dnaBase)
        {
            this.dnaBase = dnaBase;
        }

        public static implicit operator int(DnaBase dnaBase)
        {
            return (int)dnaBase.dnaBase;
        }

        public static implicit operator DnaBase(int baseInteger)
        {
            return new DnaBase((DnaBaseEnumeration)(baseInteger % 4));
        }

        public static implicit operator string(DnaBase dnaBase)
        {
            return dnaBase.ToString();
        }

        public static implicit operator DnaBase(string dnaBase)
        {
            if (dnaBase == "A")
            {
                return DnaBase.A;
            } else if (dnaBase == "C")
            {
                return DnaBase.C;
            } else if (dnaBase == "G")
            {
                return DnaBase.G;
            } else if (dnaBase == "T")
            {
                return DnaBase.T;
            }
            return DnaBase.A;
        }

        public static implicit operator DnaBase(char dnaBase)
        {
            if (dnaBase == 'A')
            {
                return DnaBase.A;
            } else if (dnaBase == 'C')
            {
                return DnaBase.C;
            } else if (dnaBase == 'G')
            {
                return DnaBase.G;
            } else if (dnaBase == 'T')
            {
                return DnaBase.T;
            }
            return DnaBase.A;

        }

        public static implicit operator char(DnaBase dnaBase)
        {
            return dnaBase.ToString().First();
        }

        public override string ToString()
        {
            return this.basePairNames[(int)this.dnaBase];
        }
    }
}
