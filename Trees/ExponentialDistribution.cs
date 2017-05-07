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
        static private Random randomUniform = new Random();

        public ExponentialDistribution(double meanValue)
        {
            this.meanValue = meanValue;
        }

        //Scaled in ms
        public double NextDouble()
        {
            double randomUniform = ExponentialDistribution.randomUniform.NextDouble();
            return (-1000)* this.meanValue * Math.Log(1 - randomUniform);
        }
    }
}
