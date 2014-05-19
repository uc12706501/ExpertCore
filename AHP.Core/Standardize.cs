using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHP.Core
{
    public delegate DecisionMatrix Standardize(DecisionMatrix toBeStandardize);

    public class Standardizer
    {
        public static DecisionMatrix ApprovedNormalize(DecisionMatrix toBeStandardize)
        {
            //归一化之后的矩阵
            DecisionMatrix standardized = new DecisionMatrix(toBeStandardize.Level, toBeStandardize.X);
            //将原始数据头填充到新数据中，所有操作都不改变原来的判断矩阵
            standardized.InsertFromMatrix(toBeStandardize);

            var factors = toBeStandardize.Level.Factors;
            int m = standardized.X;
            //标准化按照指标值，逐列进行的
            for (int j = 0; j < factors.Count; j++)
            {
                //每一列的最大值和最小值
                double columnMax = toBeStandardize.GetColumnMaxValue(j);
                double columnMin = toBeStandardize.GetColumnMinValue(j);

                //1. 如果是逆向指标，就执行
                if (factors[j].Direction == FactorDirection.Negative)
                {
                    for (int i = 0; i < toBeStandardize.X; i++)
                    {
                        standardized[i, j] = columnMax - toBeStandardize[i, j] + columnMin;
                    }
                }

                //2. 如果指标值包含负数，就执行
                bool containsNegative = false;
                for (int i = 0; i < standardized.X; i++)
                {
                    if (standardized[i, j] < 0)
                    {
                        containsNegative = true;
                        break;
                    }
                }
                //如果包含负数
                if (containsNegative)
                {
                    for (int i = 0; i < standardized.X; i++)
                    {
                        standardized[i, j] = standardized[i, j] - columnMin;
                    }
                }

                //3. 执行标准的归一化操作
                //考虑到如果m太大，会造成标准化之太小，所以统一都乘以m
                double columnSum = standardized.GetColumnSum(j);
                for (int i = 0; i < standardized.X; i++)
                {
                    standardized[i, j] = (standardized[i, j] / columnSum) * m;
                }
            }

            return standardized;

        }

        public static DecisionMatrix Normalize(DecisionMatrix toBeStandardize)
        {
            //归一化之后的矩阵
            DecisionMatrix standardized = new DecisionMatrix(toBeStandardize.Level, toBeStandardize.X);
            //将原始数据头填充到新数据中，所有操作都不改变原来的判断矩阵
            standardized.InsertFromMatrix(toBeStandardize);

            var factors = toBeStandardize.Level.Factors;
            for (int j = 0; j < factors.Count; j++)
            {
                //执行标准的归一化操作
                //获取一列的和
                double columnSum = standardized.GetColumnSum(j);
                for (int i = 0; i < standardized.X; i++)
                {
                    standardized[i, j] = (standardized[i, j] / columnSum);
                }
            }
            return standardized;
        }
    }
}
