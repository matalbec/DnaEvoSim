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
        public static DnaSequenceEvolver evolver;

        private DnaSequenceEvolver(EvolutionModel evolutionModel)
        {
            this.evolutionModel = evolutionModel;
        }

        public static void SetupEvolver(EvolutionModel model)
        {
            DnaSequenceEvolver.evolver = new DnaSequenceEvolver(model);
        }

        public DnaSequence Evolve(DnaSequence dnaSequence, double time)
        {
            DnaSequence evolvedDnaSequence = new DnaSequence(dnaSequence.Size());
            Parallel.For(0, dnaSequence.Size(), (i) =>
            {
                evolvedDnaSequence[i] = this.evolutionModel.GenerateNextBase(dnaSequence.ElementAt((int)i), time);
            }
            );
            return evolvedDnaSequence;
        }
    }
}
