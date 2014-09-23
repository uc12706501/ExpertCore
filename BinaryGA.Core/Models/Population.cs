using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChoose.BinaryGA.Impl
{
    public class Population : IEnumerable<BinaryChromosome>
    {
        private List<BinaryChromosome> _population;
        public int Generation { get; private set; }
        public int N { get; private set; }


        public Population(int n, int generation)
        {
            N = n;
            Generation = generation;
            _population = new List<BinaryChromosome>(n);
        }

        public void AddChromosome(BinaryChromosome chromosome)
        {
            _population.Add(chromosome);
        }

        public BinaryChromosome GetBestChromosome()
        {
            BinaryChromosome bestChromosome = null;
            foreach (var chromosome in _population)
            {
                if (bestChromosome == null || chromosome.Fitness > bestChromosome.Fitness)
                    bestChromosome = chromosome;
            }
            return bestChromosome;
        }

        public IEnumerator<BinaryChromosome> GetEnumerator()
        {
            return _population.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public BinaryChromosome this[int i]
        {
            get { return _population[i]; }
        }
    }
}
