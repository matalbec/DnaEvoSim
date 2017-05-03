using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class DnaSequence : IEnumerable<DnaBase>
    {
        private List<DnaBase> dnaSequence;
        public DnaSequence(string dnaSequence)
        {
            this.dnaSequence = new List<DnaBase>();
            foreach(char baseLetter in dnaSequence)
            {
                this.dnaSequence.Add(baseLetter);
            }
        }

        public DnaSequence()
        {
            this.dnaSequence = new List<DnaBase>();
        }

        public string PrintSequence()
        {
            string dnaSequenceString = string.Empty;
            foreach(DnaBase dnaBase in this.dnaSequence)
            {
                dnaSequenceString += dnaBase;
            }
            return dnaSequenceString;
        }

        public void Add(DnaBase item)
        {
            this.dnaSequence.Add(item);
        }

        public static implicit operator string(DnaSequence dnaSequence)
        {
            return dnaSequence.PrintSequence();
        }

        public IEnumerator<DnaBase> GetEnumerator()
        {
            return (IEnumerator<DnaBase>)this.dnaSequence.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
