using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChoose.AHP.Core
{
    public class AhpModel
    {
        private IList<Level> _levels;

        public IList<Level> Levels
        {
            get { return _levels; }
        }

        public AhpModel(Level topLevel)
        {
            _levels = new List<Level>();
            _levels.Add(topLevel);
        }

        /// <summary>
        /// 压入一个新的层次
        /// </summary>
        /// <param name="newLevel">新的层次结构模型</param>
        public void PushLevel(Level newLevel)
        {
            _levels.Add(newLevel);
        }

        /// <summary>
        /// 弹出最底层层次
        /// </summary>
        private void PopLevel()
        {
            _levels.RemoveAt(_levels.Count - 1);
        }

        //获得指定层的信息
        public Level GetLevelInfo(int index)
        {
            return Levels[index];
        }

        //取得层次结构模型中的最后一个层次
        public Level GetLastLevel()
        {
            return Levels.Last();
        }

        //在层次结构模型中定位某个因素在某一层
        public Level LocateFactor(Factor toFind)
        {
            Level locatedLevel = null;
            foreach (var level in Levels)
            {
                foreach (var factor in level.Factors)
                {
                    if (factor == toFind)
                    {
                        locatedLevel = level;
                    }
                }
            }
            return locatedLevel;
        }

        public void DisplayModelInfo()
        {
            Console.WriteLine("************以下是层次结构模型的主要信息*************");
            for (int i = 0; i < this.Levels.Count; i++)
            {
                if (i > 0)
                {
                    var level = this.GetLevelInfo(i);
                    foreach (var judgeMatrix in level.JudgeMatrices)
                    {
                        Console.WriteLine("{0}的判断矩阵", judgeMatrix.Key.Name);
                        judgeMatrix.Value.DisplayMatrix(DataHelper.ConsoloOutput);
                    }
                    level.GetTotalWeightVect().DisplayMatrix(DataHelper.ConsoloOutput);
                    Console.WriteLine("CI={0},RI={1},CR={2}", level.LevelCI, level.LevelRI, level.LevelCR);
                }
                else
                {
                    Console.WriteLine("顶层没有数据");
                }
                Console.WriteLine("-------------------第{0}层---------------------", i + 1);
            }
        }
    }
}
