using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinaryGA.Core;

namespace GA.Core.GAImpl
{
    public class FixmPopulationInitilizer : IPopulationInitializer
    {
        private int _N;
        private int _n;
        private int _m;

        public FixmPopulationInitilizer(int N, int n, int m)
        {
            _N = N;
            _n = n;
            _m = m;
        }

        public Population Initialize()
        {
            Population population = new Population(_N, 1);

            for (int i = 0; i < _N; i++)
                population.AddChromosome(GenerateRandomChromosome(_n, _m));

            return population;
        }

        private BinaryChromosome GenerateRandomChromosome(int n, int m)
        {
            //随你生成m个为1的位置
            ISet<int> positions = new HashSet<int>();
            Random random = new Random();
            while (positions.Count < m)
            {
                positions.Add(random.Next(n));
            }
            //根据位置生成染色体
            IList<int> c = new List<int>();
            for (int i = 0; i < n; i++)
                c.Add(positions.Contains(i + 1) ? 1 : 0);

            return new BinaryChromosome(c);
        }
    }
}
