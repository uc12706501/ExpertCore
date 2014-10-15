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

        private IList<Factor> _factors;
        private Matrix _weightVect;

        public IList<Factor> Factors
        {
            get { return _factors; }
        }

        public Matrix WeightVect
        {
            get { return _weightVect; }
        }

        #endregion

        #region 构造函数

        public DecisionMatrix(IList<Factor> factors, int rowCount, Matrix weightVect)
            : base(rowCount, factors.Count)
        {
            _factors = factors;
            _weightVect = weightVect;
        }

        public DecisionMatrix(IList<Factor> factors, int rowCount, Matrix weightVect, String name)
            : this(factors, rowCount, weightVect)
        {
            Name = name;
        }

        public DecisionMatrix(Level level, int rowCount)
            : base(rowCount, level.FactorCount)
        {
            //如果传入的是顶层，则抛出异常
            if (level.LevelCount == 1)
                throw new CustomeExcetpion("不可以是顶层元素");

            _factors = level.Factors;
            _weightVect = level.GetTotalWeightVect();
        }

        public DecisionMatrix(Level level, int rowCount, string name)
            : this(level, rowCount)
        {
            //如果传入的是顶层，则抛出异常
            //if (level.LevelCount == 1)
            //throw new CustomeExcetpion("不可以是顶层元素");

            Name = name;
        }

        #endregion

        //决策矩阵的标准化
        public DecisionMatrix GetStandardized(Standardize standardizer)
        {
            return standardizer(this);
        }

        //获取决策向量
        public Matrix GetDecisionVect(Standardize standardizer)
        {
            return standardizer(this).LeftMultipy(WeightVect);
        }

    }
}
