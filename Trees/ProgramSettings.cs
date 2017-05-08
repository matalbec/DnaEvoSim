using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class ProgramSettings
    {
        public double alpha;
        public double beta;
        public double meanValue;
        public double evolutionTime;

        private ProgramSettings(double alpha, double beta, double meanValue, double evolutionTime)
        {
            this.alpha = alpha;
            this.beta = beta;
            this.meanValue = meanValue;
            this.evolutionTime = evolutionTime;
        }

        public static ProgramSettings GetSettingsFromConsole()
        {
            double alpha = 0;
            double beta = 0;
            double meanValue = 0;
            double evolutionTime = 0;

            Console.WriteLine("Alpha paramter for kimura model:");
            alpha = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Beta paramter for kimura model:");
            beta = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Specify evolution time:");
            evolutionTime = Convert.ToDouble(Console.ReadLine());
            evolutionTime = evolutionTime * 1000;
            Console.WriteLine("Specify mean value for exponential distribution");
            meanValue = Convert.ToDouble(Console.ReadLine());

            return new ProgramSettings(alpha, beta, meanValue, evolutionTime);
        }
    }
}
