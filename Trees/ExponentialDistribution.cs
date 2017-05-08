using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class ExponentialDistribution
    {
        private double meanValue;
        private static Random randomUniform = new Random();
        public static ExponentialDistribution randomExponential;

        private ExponentialDistribution(double meanValue)
        {
            this.meanValue = meanValue;
        }

        public static void SetupExponentialDistribution(double meanValue)
        {
            ExponentialDistribution.randomExponential = new ExponentialDistribution(meanValue);
        }

        //Scaled in ms
        public double NextDouble()
        {
            double randomUniform = ExponentialDistribution.randomUniform.NextDouble();
            return (-1000)* this.meanValue * Math.Log(1 - randomUniform);
        }
    }
}
