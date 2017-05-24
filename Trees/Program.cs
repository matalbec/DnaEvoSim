using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Trees
{
    class Program
    {

        private static PhyloTree tree;
        private static Timer evolutionTimer;
        private static ProgramSettings settings;

        private static void SetupEnviroment()
        {
            Program.settings = ProgramSettings.GetSettingsFromConsole();

            ExponentialDistribution.SetupExponentialDistribution(settings.meanValue);
            EvolutionModel kimuraModel = new EvolutionModel(settings.alpha, settings.beta);
            DnaSequenceEvolver.SetupEvolver(kimuraModel);
            NodeEvolutionScheduler.SetupScheduler(settings.evolutionTime);

            //
            // Setup main evolution timer but don't enable it yet as there is no telling how long will it take the user to input sequence
            //
            Program.evolutionTimer = new Timer(settings.evolutionTime);
            Program.evolutionTimer.Elapsed += new ElapsedEventHandler(Program.EvolutionEndCallback);
            Program.evolutionTimer.AutoReset = false;
        }

        static void Main(string[] args)
        {
            string userInputSequence = string.Empty;

            SetupEnviroment();

            Console.WriteLine("Please input root sequence:");
            userInputSequence = Console.ReadLine();

            DnaSequence userSequence = new DnaSequence(userInputSequence);
            NodeEvolutionScheduler.scheduler.StartScheduler();
            PhyloTree tree = new PhyloTree(userSequence);
            Program.tree = tree;
            Program.evolutionTimer.Enabled = true;
            Console.ReadLine();
        }

        static void EvolutionEndCallback(object sender, ElapsedEventArgs args)
        {
            NodeEvolutionScheduler.scheduler.StopScheduler();
            Console.WriteLine("Printing Tree:");
            Console.WriteLine(Program.tree.PrintTree());
        }

    }
}
