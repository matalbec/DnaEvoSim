using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Trees
{
    public class PhyloTreeNode
    {
        private DnaSequence dnaSequence;
        private List<PhyloTreeNode> childrenNodes;
        private double timeFromStart;
        public double creationTime;

        private PhyloTreeNode(PhyloTreeNode parent, DnaSequence dnaSequence)
        {
            this.dnaSequence = dnaSequence;
            double timeToEvolve = ExponentialDistribution.randomExponential.NextDouble();
            this.creationTime = parent.GetTimeFromStart();
            this.timeFromStart = parent.GetTimeFromStart() + timeToEvolve;
            this.childrenNodes = new List<PhyloTreeNode>();
            NodeEvolutionScheduler.scheduler.ScheduleNodeEvolution(this, timeToEvolve);
        }

        // Constructor for root node
        public PhyloTreeNode(DnaSequence dnaSequence)
        {
            this.dnaSequence = dnaSequence;
            double timeToEvolve = ExponentialDistribution.randomExponential.NextDouble();
            this.timeFromStart = timeToEvolve;
            this.creationTime = 0;
            this.childrenNodes = new List<PhyloTreeNode>();
            NodeEvolutionScheduler.scheduler.ScheduleNodeEvolution(this, timeToEvolve);
        }

        public void EvolveNodeCallback(object sender, ElapsedEventArgs args)
        {
            this.Evolve();
        }

        private void Evolve()
        {
            DnaSequence evolvedDnaSequence1 = DnaSequenceEvolver.evolver.Evolve(this.dnaSequence, this.timeFromStart);
            DnaSequence evolvedDnaSequence2 = DnaSequenceEvolver.evolver.Evolve(this.dnaSequence, this.timeFromStart);
            List<PhyloTreeNode> childrenNodes = new List<PhyloTreeNode>()
            {
                new PhyloTreeNode(this, evolvedDnaSequence1),
                new PhyloTreeNode(this, evolvedDnaSequence2)
            };
            this.childrenNodes = childrenNodes;
        }

        public DnaSequence GetNodeSequence()
        {
            return this.dnaSequence;
        }

        public List<PhyloTreeNode> GetChildrenNodes()
        {
            return this.childrenNodes;
        }

        public double GetTimeFromStart()
        {
            return this.timeFromStart;
        }
    }
}
