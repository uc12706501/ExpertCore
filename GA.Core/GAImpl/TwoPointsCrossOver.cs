using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinaryGA.Core;
using GA.Core.Utils;

namespace GA.Core
{
    public class TwoPointsCrossOver : ICrossOverOperator
    {
        public Population Cross(Population basePopulation)
        {
            Population crossedPopulation = new Population(basePopulation.N, basePopulation.Generation);
            int i;
            for (i = 0; i < basePopulation.N; i += 2)
            {
                var crossed = ChromosomeCross(basePopulation[i], basePopulation[i + 1]);
                crossedPopulation.AddChromosome(crossed.Value1);
                crossedPopulation.AddChromosome(crossed.Value2);
            }
            if (i == basePopulation.N - 2)
            {
                var crossed = ChromosomeCross(basePopulation[i], basePopulation.GetBestChromosome());
                crossedPopulation.AddChromosome(crossed.Value1);
            }
            return crossedPopulation;
        }

        //交叉两个染色体
        private Pair<BinaryChromosome, BinaryChromosome> ChromosomeCross(BinaryChromosome c1, BinaryChromosome c2)
        {
            var operateCode = ChromosomeSub(c1, c2);
            var operatePosition = GetCrossPosition(operateCode);
            return CrossPartial(c1, c2, operatePosition);
        }

        //两个染色体相减，得到操作码
        private List<int> ChromosomeSub(BinaryChromosome c1, BinaryChromosome c2)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < c1.n; i++)
                result.Add(c1[i] - c2[i]);
            return result;
        }

        //获得交叉的位置
        private Pair<int, int> GetCrossPosition(List<int> operateCode)
        {
            var startPositions = GetStartPosition(operateCode.Count);
            int notZeroCount = 0;
            int sum = 0;
            for (int i = startPositions.Value1, j = startPositions.Value2; i >= 0; i--, j++)
            {
                if (i == j)
                    sum = operateCode[i];
                else
                    sum = operateCode[i] + operateCode[j];
                if (sum != 0)
                    notZeroCount++;
                if (sum == 0 && notZeroCount != 0)
                    return new Pair<int, int>(i, j);
            }
            return null;
        }

        //获得操作码的中间位置
        private Pair<int, int> GetStartPosition(int count)
        {
            int start, end;
            if (count % 2 == 0)
            {
                start = count / 2;
                end = start + 1;
            }
            else
            {
                start = count / 2 + 1;
                end = start;
            }
            return new Pair<int, int>(start - 1, end - 1);
        }


        //根据传入的位置交叉两个染色体
        private Pair<BinaryChromosome, BinaryChromosome> CrossPartial(BinaryChromosome c1, BinaryChromosome c2, Pair<int, int> position)
        {
            IList<int> originChromosome1 = c1.Chromosome;
            IList<int> originChromosome2 = c1.Chromosome;
            for (int i = position.Value1; i < position.Value2; i++)
            {
                int temp = originChromosome1[i];
                originChromosome1[i] = originChromosome2[i];
                originChromosome2[i] = temp;
            }
            return new Pair<BinaryChromosome, BinaryChromosome>(c1, c2);
        }
    }
}
