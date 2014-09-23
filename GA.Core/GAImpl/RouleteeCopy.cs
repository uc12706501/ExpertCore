using System;
using System.Collections.Generic;
using System.Linq;
using ExpertChoose.BinaryGA.Impl;

namespace ExpertChoose.BinaryGA.Impl
{
    //轮盘赌选择复制
    public class RouleteeCopy : ICopyOperator
    {
        public Population Copy(Population parentGeneration)
        {
            var rouletteRate = GetRouletteRate(parentGeneration);
            Population nextGeneration = new Population(parentGeneration.N, parentGeneration.Generation + 1);
            for (int i = 0; i < parentGeneration.N; i++)
                nextGeneration.AddChromosome(GenerateNextChromosome(rouletteRate));
            return nextGeneration;
        }

        private List<Utils.Tuple<BinaryChromosome, double, double>> GetRouletteRate(Population population)
        {
            //计算合适配度
            double sum = population.Sum(x => x.Fitness);
            double addedRate = 0;
            var results = new List<Utils.Tuple<BinaryChromosome, double, double>>();
            foreach (var chromosome in population)
            {
                double rate = chromosome.Fitness / sum;
                var tuple = new Utils.Tuple<BinaryChromosome, double, double>() { Value1 = chromosome, Value2 = addedRate, Value3 = rate };
                results.Add(tuple);
                addedRate += rate;
            }
            return results;
        }

        private BinaryChromosome GenerateNextChromosome(IEnumerable<Utils.Tuple<BinaryChromosome, double, double>> rouletteRate)
        {
            Random random = new Random();
            double randomValue = random.NextDouble();
            foreach (var tuple in rouletteRate)
            {
                if (randomValue > tuple.Value2 && randomValue <= tuple.Value2 + tuple.Value3)
                    return tuple.Value1;
            }
            return null;
        }
    }
}
