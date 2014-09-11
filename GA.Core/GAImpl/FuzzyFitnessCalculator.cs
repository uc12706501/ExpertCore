using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinaryGA.Core;

namespace GA.Core.GAImpl
{
    public class FuzzyFitnessCalculator : IFitnessCalculator
    {
        private SubjectionTable _subjectionTable;
        private IList<double> _wights;

        public FuzzyFitnessCalculator(SubjectionTable table, IList<double> wights)
        {
            _subjectionTable = table;
            _wights = wights;
        }

        public double CalculateFitness(BinaryChromosome chromosome)
        {
            return Pair(chromosome) - Math.Abs(Hate(chromosome));
        }

        //计算匹配度
        private double Pair(BinaryChromosome chromosome)
        {
            double sumPair = 0;
            for (int i = 0; i < chromosome.n; i++)
                for (int j = 0; j < 2; j++)
                    sumPair += _wights[j] * _subjectionTable[i, j] * chromosome[i];
            return sumPair;
        }

        //计算排斥度
        private double Hate(BinaryChromosome chromosome)
        {
            var avgs = CalAvg(chromosome);
            double sumHate = 0;
            for (int i = 0; i < chromosome.n; i++)
                for (int j = 0; j < 2; j++)
                    sumHate += _wights[j] * Math.Abs(_subjectionTable[i, j] - avgs[j]) * chromosome[i];
            return sumHate;
        }

        //计算每一列的平均值
        private List<double> CalAvg(BinaryChromosome chromosome)
        {
            List<double> avgs = new List<double>();
            for (int j = 0; j < 2; j++)
            {
                double thisSum = 0;
                for (int i = 0; i < chromosome.n; i++)
                {
                    thisSum += chromosome[i] * _subjectionTable[i, j];
                }
                avgs.Add(thisSum / chromosome.n);
            }
            return avgs;
        }
    }
}
