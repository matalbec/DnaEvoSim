using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{

    public class DnaSequenceEnumerator : IEnumerator<DnaBase>
    {
        private string dnaSequence;
        private int currentPosition;

        public DnaSequenceEnumerator(string dnaSequence)
        {
            this.dnaSequence = dnaSequence;
            this.currentPosition = -1;
        }

        public bool MoveNext()
        {
            this.currentPosition++;
            return (this.currentPosition < this.dnaSequence.Length);
        }

        public void Reset()
        {
            this.currentPosition = -1;
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public DnaBase Current
        {
            get
            {
                return this.dnaSequence.ElementAt(this.currentPosition);
            }
        }

        void IDisposable.Dispose()
        {

        }
    }

    public class DnaSequence : IEnumerable<DnaBase>
    {
        private string dnaSequence;
        public DnaSequence(string dnaSequence)
        {
            this.dnaSequence = dnaSequence;
        }

        public DnaSequence()
        {
            this.dnaSequence = string.Empty;
        }

        public DnaSequence(int size)
        {
            this.dnaSequence = new string('*', size);
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
            this.dnaSequence += item;
        }

        public int Size()
        {
            return this.dnaSequence.Length;
        }

        public DnaBase ElementAt(int position)
        {
            return this.dnaSequence.ElementAt(position);
        }

        public static implicit operator string(DnaSequence dnaSequence)
        {
            return dnaSequence.PrintSequence();
        }

        public static implicit operator DnaSequence(string dnaSequenceAsString)
        {
            return new DnaSequence(dnaSequenceAsString);
        }

        public override string ToString()
        {
            return this.PrintSequence();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator<DnaBase> IEnumerable<DnaBase>.GetEnumerator()
        {
            return (IEnumerator<DnaBase>)this.GetEnumerator();
        }

        public DnaSequenceEnumerator GetEnumerator()
        {
            return new DnaSequenceEnumerator(this.dnaSequence);
        }

        public DnaBase this[int index]
        {
            get
            {
                return this.dnaSequence[index];
            }
            set
            {
                StringBuilder sb = new StringBuilder(this.dnaSequence);
                sb[index] = value;
                this.dnaSequence = sb.ToString();
            }
        }

    }
}
