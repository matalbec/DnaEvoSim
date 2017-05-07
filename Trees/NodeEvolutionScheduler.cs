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
        private Timer mainTimer;
        private List<Timer> timers;
        private bool SchedulerActive;

        public NodeEvolutionScheduler(double overallEvolutionTime)
        {
            this.overallEvolutionTime = overallEvolutionTime;
            this.SchedulerActive = false;
            this.mainTimer = new Timer(overallEvolutionTime);
            this.mainTimer.Elapsed += new ElapsedEventHandler(this.StopScheduler);
            this.timers = new List<Timer>();
            this.mainTimer.Enabled = true;
            this.SchedulerActive = true;
        }

        public void ScheduleNodeEvolution(PhyloTreeNode node, double timeToEvolve)
        {
            if (this.SchedulerActive)
            {
                Timer evolutionTimer = new Timer(timeToEvolve);
                evolutionTimer.Elapsed += new ElapsedEventHandler(node.EvolveNodeCallback);
                evolutionTimer.Enabled = true;
                this.timers.Add(evolutionTimer);
            }
        }

        private void StopScheduler(object sender, ElapsedEventArgs args)
        {
            this.SchedulerActive = false;
        }
    }
}
