using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpertChoose.BinaryGA.Impl;

namespace ExpertChoose.BinaryGA.Impl
{
    public class BoundaryMutation : IMutateOperator
    {
        //变异概率
        private readonly double _muaterate;
        private double _grate;

        public BoundaryMutation(double grate = 0.25, double muaterate = 0.06)
        {
            _muaterate = muaterate;
            _grate = grate;
        }

        public Population Mutate(Population basePopulation)
        {
            List<int> chromosomeToMutate = GetMutateChromosome(basePopulation);
            Population mutatedPopulation = new Population(basePopulation.N, basePopulation.Generation);

            for (int i = 0; i < basePopulation.N; i++)
            {
                if (chromosomeToMutate.Contains(i))
                    mutatedPopulation.AddChromosome(MutateSingle(basePopulation[i]));
                else
                    mutatedPopulation.AddChromosome(basePopulation[i]);
            }

            return mutatedPopulation;
        }

        //获得种群中变异染色体的位置
        private List<int> GetMutateChromosome(Population population)
        {
            int muteteCount = (int)(population.N * _muaterate);
            Random random = new Random();
            List<int> chromosomes = new List<int>();
            for (int i = 0; i < muteteCount; i++)
            {
                int pos;
                do
                {
                    pos = random.Next(population.N);
                } while (chromosomes.Contains(pos));
                chromosomes.Add(pos);
            }
            return chromosomes;
        }

        //对一个染色体进行变异操作
        private BinaryChromosome MutateSingle(BinaryChromosome chromosome)
        {
            IList<int> muteted = new List<int>(chromosome.Chromosome);
            int muteCount = (int)(chromosome.n * _grate);

            int end = chromosome.n - 1;//变异结束点
            int start = end - muteCount;//变异开始点
            for (int i = start, j = end; i < muteCount / 2; i++, j--)
            {
                int temp = chromosome[i];
                chromosome[i] = chromosome[j];
                chromosome[j] = temp;
            }

            return new BinaryChromosome(muteted);
        }
    }
}
