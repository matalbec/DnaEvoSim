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
        private DnaSequenceEvolver evolver;
        private double timeFromStart;
        private NodeEvolutionScheduler scheduler;
        private ExponentialDistribution exp;

        //
        //@TODO: Refactor those constructors to use static members
        //
        public PhyloTreeNode(PhyloTreeNode parent, DnaSequence dnaSequence, DnaSequenceEvolver evolver, ExponentialDistribution exp, NodeEvolutionScheduler scheduler)
        {
            this.dnaSequence = dnaSequence;
            double timeToEvolve = exp.NextDouble();
            this.exp = exp;
            this.evolver = evolver;
            this.scheduler = scheduler;
            this.timeFromStart = parent.GetTimeFromStart() + timeToEvolve;
            this.childrenNodes = new List<PhyloTreeNode>();
            scheduler.ScheduleNodeEvolution(this, timeToEvolve);
        }

        // Constructor for root node
        public PhyloTreeNode(DnaSequence dnaSequence, DnaSequenceEvolver evolver, ExponentialDistribution exp, NodeEvolutionScheduler scheduler)
        {
            this.dnaSequence = dnaSequence;
            double timeToEvolve = exp.NextDouble();
            this.exp = exp;
            this.evolver = evolver;
            this.scheduler = scheduler;
            this.timeFromStart = timeToEvolve;
            this.childrenNodes = new List<PhyloTreeNode>();
            scheduler.ScheduleNodeEvolution(this, timeToEvolve);
        }

        public void EvolveNodeCallback(object sender, ElapsedEventArgs args)
        {
            this.Evolve();
        }

        private void Evolve()
        {
            DnaSequence evolvedDnaSequence1 = this.evolver.Evolve(this.dnaSequence, this.timeFromStart);
            DnaSequence evolvedDnaSequence2 = this.evolver.Evolve(this.dnaSequence, this.timeFromStart);
            List<PhyloTreeNode> childrenNodes = new List<PhyloTreeNode>()
            {
                new PhyloTreeNode(this, evolvedDnaSequence1, this.evolver, this.exp, this.scheduler),
                new PhyloTreeNode(this, evolvedDnaSequence2, this.evolver, this.exp, this.scheduler)
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
