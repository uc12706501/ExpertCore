using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using ExpertChoose.AHP.Core;

namespace ExpertChoose.AHP.WinformSystem
{
    public static class ExtendMethods
    {
        //将决策矩阵转换成ExpertList列表
        public static IList<ExpertModel> ToExpertList(this DecisionMatrix decisionMatrix)
        {
            //如果判断矩阵为空，就构造一个空的列表返回
            if (decisionMatrix == null || decisionMatrix.X == 0)
            {
                return new List<ExpertModel>() { new ExpertModel() };
            }

            //检测维数
            if (decisionMatrix.Y < 14)
                throw new ArgumentException("维数不匹配");

            //依次添加每个专家的信息
            IList<ExpertModel> expertModels = new List<ExpertModel>();
            for (int i = 0; i < decisionMatrix.X; i++)
            {
                expertModels.Add(new ExpertModel()
                {
                    B1 = decisionMatrix[i, 0],
                    B2 = decisionMatrix[i, 1],
                    B3 = decisionMatrix[i, 2],
                    B4 = decisionMatrix[i, 3],
                    B5 = decisionMatrix[i, 4],
                    B6 = decisionMatrix[i, 5],
                    B7 = decisionMatrix[i, 6],
                    B8 = decisionMatrix[i, 7],
                    B9 = decisionMatrix[i, 8],
                    B10 = decisionMatrix[i, 9],
                    B11 = decisionMatrix[i, 10],
                    B12 = decisionMatrix[i, 11],
                    B13 = decisionMatrix[i, 12],
                    B14 = decisionMatrix[i, 13],
                });
            }
            return expertModels;
        }


        //将ExpertList的数据导入到决策矩阵中
        public static DecisionMatrix SetDecisionMatrix(this DecisionMatrix decisionMatrix, IList<ExpertModel> expertModels)
        {
            DecisionMatrix newDecisionMatrix = new DecisionMatrix(decisionMatrix.Level, expertModels.Count);

            for (int i = 0; i < expertModels.Count; i++)
            {
                newDecisionMatrix[i, 0] = expertModels[i].B1;
                newDecisionMatrix[i, 1] = expertModels[i].B2;
                newDecisionMatrix[i, 2] = expertModels[i].B3;
                newDecisionMatrix[i, 3] = expertModels[i].B4;
                newDecisionMatrix[i, 4] = expertModels[i].B5;
                newDecisionMatrix[i, 5] = expertModels[i].B6;
                newDecisionMatrix[i, 6] = expertModels[i].B7;
                newDecisionMatrix[i, 7] = expertModels[i].B8;
                newDecisionMatrix[i, 8] = expertModels[i].B9;
                newDecisionMatrix[i, 9] = expertModels[i].B10;
                newDecisionMatrix[i, 10] = expertModels[i].B11;
                newDecisionMatrix[i, 11] = expertModels[i].B12;
                newDecisionMatrix[i, 12] = expertModels[i].B13;
                newDecisionMatrix[i, 13] = expertModels[i].B14;
            }

            return newDecisionMatrix;
        }

        //将矩阵转化成DataTable
        public static DataTable ToDataTable(this Matrix matrix)
        {
            DataTable table = new DataTable();
            for (int i = 0; i < matrix.Y; i++)
            {
                table.Columns.Add(i.ToString(), typeof(double));
            }
            for (int i = 0; i < matrix.X; i++)
            {
                object[] values = new object[matrix.Y];
                for (int j = 0; j < matrix.Y; j++)
                {
                    values[j] = matrix[i, j];
                }
                table.Rows.Add(values);
            }
            return table;
        }

        //将判断矩阵设置到对应的层次
        public static void SetJudgeMatrices(this IList<JudgeMatrixPair> judgeMatrixPairs, Level level, bool isApproved)
        {
            Factor currentFactor;
            foreach (var judgeMatrixPair in judgeMatrixPairs)
            {
                currentFactor = judgeMatrixPair.AffectedFactor;
                if (level.JudgeMatrices.ContainsKey(currentFactor))
                {
                    level.JudgeMatrices[currentFactor] = isApproved
                                                             ? judgeMatrixPair.ApprovedGen
                                                             : judgeMatrixPair.NormalGen;
                }
            }
        }
    }
}
