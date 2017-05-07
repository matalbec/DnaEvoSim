using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Trees
{
    public class NodeEvolutionScheduler
    {
        private double overallEvolutionTime;
        private List<Timer> timers;
        private bool SchedulerActive;

        public NodeEvolutionScheduler(double overallEvolutionTime)
        {
            this.overallEvolutionTime = overallEvolutionTime;
            this.SchedulerActive = false;
            this.timers = new List<Timer>();
            this.SchedulerActive = true;
        }

        public void ScheduleNodeEvolution(PhyloTreeNode node, double timeToEvolve)
        {
            if (this.SchedulerActive)
            {
                Timer evolutionTimer = new Timer(timeToEvolve);
                evolutionTimer.Elapsed += new ElapsedEventHandler(node.EvolveNodeCallback);
                evolutionTimer.AutoReset = false;
                evolutionTimer.Enabled = true;
                this.timers.Add(evolutionTimer);
            }
        }

        public void StopScheduler()
        {
            this.SchedulerActive = false;
        }
    }
}
