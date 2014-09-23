using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpertChoose.BinaryGA.Impl;

namespace ExpertChoose.BinaryGA.Impl.GAImpl
{
    public class FitnessMeetStopCondition : IStopCondition
    {
        private double _targetFatness;

        public FitnessMeetStopCondition(double targetFatness)
        {
            _targetFatness = targetFatness;
        }

        public bool Check(Population population)
        {
            if (population.GetBestChromosome().Fitness >= _targetFatness)
                return true;
            return false;
        }
    }
}
