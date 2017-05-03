using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class DnaSequenceEvolver
    {
        private EvolutionModel evolutionModel;

        public DnaSequenceEvolver(EvolutionModel evolutionModel)
        {
            this.evolutionModel = evolutionModel;
        }

        public DnaSequence Evolve(DnaSequence dnaSequence, double time)
        {
            DnaSequence evolvedDnaSequence = new DnaSequence();
            foreach(DnaBase dnaBase in dnaSequence)
            {
                evolvedDnaSequence.Add(this.evolutionModel.GenerateNextBase(dnaBase, time));
            }
            return evolvedDnaSequence;
        }
    }
}
