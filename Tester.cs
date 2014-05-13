using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AHP.Core;

namespace ExpertChooseCore
{
    public static class Tester
    {
        public static void MatrixTest()
        { //创建一个3*3的矩阵，并通过List赋值
            Matrix m1 = new Matrix(3, 3, "m1");
            IList<double> listsource = new List<double>() { 3, 2, 1, 4, 5, 6, 7, 8, 9, 11 };
            m1.InsertDataFromList(listsource);
            m1.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //创建一个3*3矩阵，然后通过默认方法赋值
            Matrix m2 = new Matrix(3, 3, "m2");
            m2.InsertMatrix(MatrixHelper.DefaultInput);
            m2.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //m1+m2，然后赋值给m3
            Matrix m3 = m1.Add(m2);
            m3.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //m1*4
            Matrix m4 = m2.DotMultiply(4);
            m4.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //m5与m6相乘
            Matrix m5 = new Matrix(2, 2, "m5");
            m5.InsertDataFromList(new List<double>() { 1, 1, -1, -1 });
            m5.DisplayMatrix(MatrixHelper.ConsoloOutput);
            Matrix m6 = new Matrix(2, 2, "m6");
            m6.InsertDataFromList(new List<double>() { -1, 2, 3, 0 });
            m6.DisplayMatrix(MatrixHelper.ConsoloOutput);
            Matrix m7 = m5.LeftMultipy(m6);
            m7.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //找出m8中最大的值
            Matrix m8 = new Matrix(4, 4, "m8");
            m8.InsertDataFromList(new List<double>() { 1, 2, 4, 7, 6, 7, 8, 7, 9, 8, 7, 15, 4, 5, 8, 8, 9, 45, 5 });
            m8.DisplayMatrix(MatrixHelper.ConsoloOutput);
            int x8, y8;
            double m8max = m8.GetMaxValue(out x8, out y8);
            Console.WriteLine(string.Format("最大值坐标是第{0}行第{1}列，为{2}\n", x8 + 1, y8 + 1, m8max));

            //求m8中所有元素之和
            double sumRow1 = m8.GetSum(0, 0, 0, 3);
            Console.WriteLine(string.Format("矩阵m8中第一行值之和为{0}", sumRow1));
            double sumColumn1 = m8.GetSum(0, 0, 3, 0);
            Console.WriteLine(string.Format("矩阵m8中第一列值之和为{0}", sumColumn1));
            double sum = m8.GetSum();
            Console.WriteLine("矩阵m8中所有值之和{0}\n", sum);

            //求m8中元素的最大绝对值
            int abma, abmb;
            double maxAbs = m8.GetMaxAbsoluteValue(out abma, out abmb);
            Console.WriteLine("m8的最大绝对值为第{1}行第{2}列的{0}\n", maxAbs, abma, abmb);

            //获得m8的一个子矩阵(0,0)->(2,1)
            Matrix m9 = m8.GetSubMatrix(0, 0, 2, 1);
            m9.DisplayMatrix(MatrixHelper.ConsoloOutput);
            m9 = m8.GetSubMatrix(0, 2, 3, 2);
            m9.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //获得m8的归一化矩阵
            //Matrix m10 = m8.GetNormalized();
            //m10.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //获取m11的转置矩阵
            Matrix m11 = new Matrix(4, 2, "m11");
            m11.InsertDataFromList(new List<double>() { 1, 2, 4, 7, 6, 7, 8, 7, 9, 8, 7, 15, 4, 5, 8, 8, 9, 45, 5 });
            m11.DisplayMatrix(MatrixHelper.ConsoloOutput);
            Matrix m12 = m11.GetTranspose();
            m12.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //获取m13的转置矩阵
            Matrix m13 = new Matrix(5, 5, "m13");
            //m13.InsertDataFromList(new List<double>() { 1, -3, 3, 3, -5, 3, 6, -5, 4 }); //结果为4，(1,1,2)
            //m13.InsertDataFromList(new List<double>() { 2, 2, -2, 2, 5, -4, -2, -4, 5 }); 
            //m13.InsertDataFromList(new List<double>() {4,2,-5,6,4,-9,5,3,-7 }); //结果为1，(1,1,1)
            m13.InsertDataFromList(new List<double>
                    {
                        1, 0.5, 4, 3, 3, 
                        2, 1, 7, 5, 5, 
                        1 / 4.0, 1 / 7.0, 1, 1 / 2.0, 1/3.0,
                        1 / 3.0, 1 / 5.0, 2, 1, 1, 
                        1 / 3.0, 1 / 5.0, 3, 1, 1
                    });
            //m13.InsertMatrix(MatrixHelper.ConsoloInput);
            m13.DisplayMatrix(MatrixHelper.ConsoloOutput);
            double eiginvalue;
            Matrix m14 = m13.Power(out eiginvalue);
            Console.WriteLine(string.Format("矩阵m14对应的最大特征值为{0}", eiginvalue));
            m14.DisplayMatrix(MatrixHelper.ConsoloOutput);
        }

        public static void JudgeMatrixTest()
        {
            JudgeMatrix jm1 = new JudgeMatrix(5, "测试矩阵");
            jm1.InsertDataFromList(
                new List<double>
                    {
                        1, 0.5, 4, 3, 3, 
                        2, 1, 7, 5, 5, 
                        1 / 4.0, 1 / 7.0, 1, 1 / 2.0, 1 / 3.0,
                        1 / 3.0, 1 / 5.0, 2, 1, 1, 
                        1 / 3.0, 1 / 5.0, 3, 1, 1
                    });
            jm1.DisplayMatrix(MatrixHelper.ConsoloOutput);
            double eiginValue;
            var vect1 = jm1.SingleFactorWightVect(out eiginValue);
            vect1.DisplayMatrix(MatrixHelper.ConsoloOutput);
            Console.WriteLine("测试矩阵的\n特征值={3},\nCI={0},\nRI={1},\nCR={2}", jm1.CI, jm1.RI, jm1.CR, eiginValue);
        }

        public static void AhpModelTest()
        {

            //构造第一层
            IList<Factor> factors1 = new List<Factor>() { new Factor("Z") };
            Level level1 = new Level(null, factors1, null, null);
            AhpModel ahpModel = new AhpModel(level1);

            //构造第二层
            //第二层因素
            IList<Factor> factors2 = new List<Factor> { 
                new Factor("A1"), 
                new Factor("A2"), 
                new Factor("A3"), 
                new Factor("A4"), 
                new Factor("A")
            };
            //第二层关系矩阵
            Matrix level2Relation = new Matrix(5, 1);
            level2Relation.InsertDataFromList(new List<double> { 1, 1, 1, 1, 1 });
            //第二层判断矩阵
            JudgeMatrix level2JudugeMatrix1 = new JudgeMatrix(5);
            level2JudugeMatrix1.InsertDataFromList(new List<double>
                {
                    1,1/2.0,4,3,3,
                    2,1,7,5,5,
                    1/4,1/7,1,1/2.0,1/3.0,
                    1/3.0,1/5.0,2,1,1,
                    1/3.0,1/5.0,3,1,1
                });
            //加入到判断矩阵序列
            Dictionary<Factor, JudgeMatrix> level2Judges = new Dictionary<Factor, JudgeMatrix>();
            level2Judges.Add(level1.Factors[0], level2JudugeMatrix1);
            Level level2 = new Level(level1, factors2, level2Relation, level2Judges);
            //加入到模型中
            ahpModel.PushLevel(level2);

            //构造第三层次
            IList<Factor> factors3 = new List<Factor> { 
                new Factor("B1"), 
                new Factor("B2"), 
                new Factor("B3"), 
            };
            //第三层关系矩阵
            Matrix level3Relation = new Matrix(3, 5);
            level3Relation.InsertDataFromList(new List<double> 
            { 
                1, 1, 1, 1, 1,
                1, 1, 1, 1, 1,
                1, 1, 1, 1, 1 
            });
            //第三层判断矩阵
            JudgeMatrix level3JudugeMatrix1 = new JudgeMatrix(3);
            level3JudugeMatrix1.InsertDataFromList(new List<double>
                {
                    1,2,5,
                    1/2.0,1,2,
                    1/5.0,1/2.0,1
                });
            JudgeMatrix level3JudugeMatrix2 = new JudgeMatrix(3);
            level3JudugeMatrix2.InsertDataFromList(new List<double>
                {
                    1,1/3.0,1/8.0,
                    3,1,1/3.0,
                    8,3,1
                });
            JudgeMatrix level3JudugeMatrix3 = new JudgeMatrix(3);
            level3JudugeMatrix3.InsertDataFromList(new List<double>
                {
                    1,1,3,
                    1,1,3,
                    1/3.0,1/3.0,1
                });
            JudgeMatrix level3JudugeMatrix4 = new JudgeMatrix(3);
            level3JudugeMatrix4.InsertDataFromList(new List<double>
                {
                    1,3,4,
                    1/3.0,1,1,
                    1/4.0,1,1
                });
            JudgeMatrix level3JudugeMatrix5 = new JudgeMatrix(3);
            level3JudugeMatrix5.InsertDataFromList(new List<double>
                {
                    1,1,1/4.0,
                    1,1,1/4.0,
                    4,4,1
                });
            //加入到判断矩阵序列
            Dictionary<Factor, JudgeMatrix> level3Judges = new Dictionary<Factor, JudgeMatrix>();
            level3Judges.Add(level2.Factors[0], level3JudugeMatrix1);
            level3Judges.Add(level2.Factors[1], level3JudugeMatrix2);
            level3Judges.Add(level2.Factors[2], level3JudugeMatrix3);
            level3Judges.Add(level2.Factors[3], level3JudugeMatrix4);
            level3Judges.Add(level2.Factors[4], level3JudugeMatrix5);
            Level level3 = new Level(level2, factors3, level3Relation, level3Judges);
            //加入到模型中
            ahpModel.PushLevel(level3);

            //测试数据
            ahpModel.GetLevelInfo(3).GetTotalWeightVect().DisplayMatrix(MatrixHelper.ConsoloOutput);
        }
    }
}
