using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class EvolutionModel
    {
        private delegate double EvolutionProbability(double time);
        private List<List<EvolutionProbability>> transitionMatrix;
        private double alphaParam;
        private double betaParam;
        static private Random randomGen = new Random();

        public EvolutionModel(double alpha, double beta)
        {
            this.alphaParam = alpha;
            this.betaParam = beta;
            this.InitializeTransitionMatrix();
        }

        private void InitializeTransitionMatrix()
        {
            this.transitionMatrix = new List<List<EvolutionProbability>>()
            {
                new List<EvolutionProbability>() // Adenine row
                {
                    this.SelfTransitionProbability,
                    this.TransversionProbability,
                    this.TransitionProbability,
                    this.TransversionProbability,
                },
                new List<EvolutionProbability>() //Cytosine row
                {
                    this.TransversionProbability,
                    this.SelfTransitionProbability,
                    this.TransversionProbability,
                    this.TransitionProbability
                },
                new List<EvolutionProbability>() // Guanine row
                {
                    this.TransitionProbability,
                    this.TransversionProbability,
                    this.SelfTransitionProbability,
                    this.TransversionProbability
                },
                new List<EvolutionProbability>() // Tymine row
                {
                    this.TransversionProbability,
                    this.TransitionProbability,
                    this.TransversionProbability,
                    this.SelfTransitionProbability
                }
            };
        }

        public DnaBase GenerateNextBase(DnaBase currentBase, double time)
        {
            List<double> TransitionVector = this.GetTransitionVector(currentBase, time);
            double randomResult = EvolutionModel.randomGen.NextDouble();
            double tresholdProbability = 0;
            for (int i = currentBase; i < currentBase + 4; i++)
            {
                tresholdProbability += TransitionVector.ElementAt(i % 4);
                if (randomResult <= tresholdProbability)
                {
                    return i;
                }
            }
            return currentBase;
        }

        private List<double> GetTransitionVector(DnaBase currentBase, double time)
        {
            List<EvolutionProbability> EvolutionVector = this.transitionMatrix.ElementAt((int)currentBase);
            List<double> TransitionVector = new List<double>()
            {
                EvolutionVector.ElementAt(DnaBase.A)(time),
                EvolutionVector.ElementAt(DnaBase.C)(time),
                EvolutionVector.ElementAt(DnaBase.G)(time),
                EvolutionVector.ElementAt(DnaBase.T)(time)
            };
            return TransitionVector;
        }

        private double TransversionProbability(double time)
        {
            if (this.betaParam == 0)
            {
                return 0;
            } else
            {
                return (1 - Math.Exp(-4 * this.betaParam * time)) / 4.0;
            }
        }

        private double TransitionProbability(double time)
        {
            if (this.alphaParam == 0)
            {
                return 0;
            } else
            {
                return (1 + Math.Exp(-4 * this.betaParam * time) - (2 * Math.Exp(-2 * (this.alphaParam + this.betaParam) * time))) / 4.0;
            }
        }

        private double SelfTransitionProbability(double time)
        {
            return 1 - 2 * this.TransitionProbability(time) - this.TransversionProbability(time);
        }
    }
}
