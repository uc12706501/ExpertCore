using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHP.Core
{
    //决策矩阵
    public class DecisionMatrix : Matrix
    {
        #region 字段和属性

        private Level level;

        public Level Level
        {
            get { return level; }
        }

        #endregion

        #region 构造函数

        public DecisionMatrix(Level level, int elementCount)
            : base(elementCount, level.FactorCount)
        {
            //如果传入的是顶层，则抛出异常
            if (level.LevelCount == 1)
                throw new CustomeExcetpion("不可以是顶层元素");

            this.level = level;
        }

        public DecisionMatrix(Level level, int elementCount, string name)
            : base(elementCount, level.FactorCount, name)
        {
            //如果传入的是顶层，则抛出异常
            if (level.LevelCount == 1)
                throw new CustomeExcetpion("不可以是顶层元素");

            this.level = level;
        }

        #endregion

        public DecisionMatrix Standardize(IStandardizer standardizer)
        {
            return standardizer.Standardize(this);
        }

        //获取决策向量
        public Matrix GetDecisionVect(IStandardizer standardizer)
        {
            return Standardize(standardizer).LeftMultipy(level.GetTotalWeightVect());
        }

    }
}
