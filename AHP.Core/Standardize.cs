using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHP.Core
{
    public delegate DecisionMatrix Standardize(DecisionMatrix toBeStandardized);

    public class Standardizer
    {
        public static DecisionMatrix ApprovedNormalize(DecisionMatrix toBeStandardized)
        {
            //归一化之后的矩阵
            DecisionMatrix standardized = new DecisionMatrix(toBeStandardized.Factors, toBeStandardized.X, toBeStandardized.WeightVect);
            //将原始数据填充到新数据中，所有操作都不改变原来的判断矩阵
            standardized.InsertFromMatrix(toBeStandardized);

            var factors = standardized.Factors;
            int m = standardized.X;
            //标准化按照指标值，逐列进行的
            for (int j = 0; j < factors.Count; j++)
            {

                //新增规则：考虑中间最大的情况
                if (factors[j].Direction == FactorDirection.Middle)
                {
                    for (int i = 0; i < standardized.X; i++)
                    {
                        if (standardized[i, j] > factors[j].MaxValue)
                            standardized[i, j] = 2 * factors[j].MaxValue - standardized[i, j];
                    }
                }

                //1. 如果是逆向指标，就改为正向指标
                if (factors[j].Direction == FactorDirection.Negative)
                {
                    for (int i = 0; i < standardized.X; i++)
                    {
                        standardized[i, j] = standardized.GetColumnMaxValue(j) - standardized[i, j] + standardized.GetColumnMinValue(j);
                    }
                }

                //2. 如果指标值包含负数，就修改为正数
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
                        standardized[i, j] = standardized[i, j] - standardized.GetColumnMinValue(j);
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

        public static DecisionMatrix Normalize(DecisionMatrix toBeStandardized)
        {
            //归一化之后的矩阵
            DecisionMatrix standardized = new DecisionMatrix(toBeStandardized.Factors, toBeStandardized.X, toBeStandardized.WeightVect);
            //将原始数据头填充到新数据中，所有操作都不改变原来的判断矩阵
            standardized.InsertFromMatrix(toBeStandardized);

            var factors = toBeStandardized.Factors;
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
