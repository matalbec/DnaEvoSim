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
        public static NodeEvolutionScheduler scheduler;

        private NodeEvolutionScheduler(double overallEvolutionTime)
        {
            this.overallEvolutionTime = overallEvolutionTime;
            this.SchedulerActive = false;
            this.timers = new List<Timer>();
        }

        public static void SetupScheduler(double overallEvolutionTime)
        {
            NodeEvolutionScheduler.scheduler = new NodeEvolutionScheduler(overallEvolutionTime);
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

        public void StartScheduler()
        {
            this.SchedulerActive = true;
        }

        public void StopScheduler()
        {
            this.SchedulerActive = false;
            foreach(var timer in this.timers)
            {
                timer.Enabled = false;
                timer.Close();
            }
        }
    }
}
