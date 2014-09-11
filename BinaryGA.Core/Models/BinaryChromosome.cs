using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryGA.Core
{
    public class BinaryChromosome
    {
        public BinaryChromosome(IList<int> chromosome)
        {
            n = chromosome.Count;
            Chromosome = chromosome;
        }

        private IList<int> _chromosome;
        public IList<int> Chromosome
        {
            get { return _chromosome; }
            private set
            {
                _chromosome = new List<int>(n);
                for (int i = 0; i < n; i++)
                {
                    _chromosome.Add(value[i] == 0 ? 0 : 1);
                }
            }
        }
        //适应度
        public double Fitness { get; set; }
        //基因的个数
        public int n { get; private set; }

        public int this[int i]
        {
            get { return _chromosome[i]; }
            set { _chromosome[i] = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < _chromosome.Count; i++)
                sb.Append(i + " ");
            sb.Append("]");

            return sb.ToString();
        }
    }
}
