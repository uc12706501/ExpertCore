using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AHP.Core;

namespace ExpertChooseCore
{
    public static class Tester
    {
        #region 矩阵测试

        public static void MatrixTest()
        {
            //创建一个3*3的矩阵，并通过List赋值
            Matrix m1 = new Matrix(3, 3, "m1");
            IList<double> listsource = new List<double>() { 3, 2, 1, 4, 5, 6, 7, 8, 9, 11 };
            m1.InsertDataFromList(listsource);
            m1.DisplayMatrix(DataHelper.ConsoloOutput);

            //创建一个3*3矩阵，然后通过默认方法赋值
            Matrix m2 = new Matrix(3, 3, "m2");
            m2.InsertMatrix(DataHelper.DefaultInput);
            m2.DisplayMatrix(DataHelper.ConsoloOutput);

            //m1+m2，然后赋值给m3
            Matrix m3 = m1.Add(m2);
            m3.DisplayMatrix(DataHelper.ConsoloOutput);

            //m1*4
            Matrix m4 = m2.DotMultiply(4);
            m4.DisplayMatrix(DataHelper.ConsoloOutput);

            //m5与m6相乘
            Matrix m5 = new Matrix(2, 2, "m5");
            m5.InsertDataFromList(new List<double>() { 1, 1, -1, -1 });
            m5.DisplayMatrix(DataHelper.ConsoloOutput);
            Matrix m6 = new Matrix(2, 2, "m6");
            m6.InsertDataFromList(new List<double>() { -1, 2, 3, 0 });
            m6.DisplayMatrix(DataHelper.ConsoloOutput);
            Matrix m7 = m5.LeftMultipy(m6);
            m7.DisplayMatrix(DataHelper.ConsoloOutput);

            //找出m8中最大的值
            Matrix m8 = new Matrix(4, 4, "m8");
            m8.InsertDataFromList(new List<double>() { 1, 2, 4, 7, 6, 7, 8, 7, 9, 8, 7, 15, 4, 5, 8, 8, 9, 45, 5 });
            m8.DisplayMatrix(DataHelper.ConsoloOutput);
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
            m9.DisplayMatrix(DataHelper.ConsoloOutput);
            m9 = m8.GetSubMatrix(0, 2, 3, 2);
            m9.DisplayMatrix(DataHelper.ConsoloOutput);

            //获得m8的归一化矩阵
            //Matrix m10 = m8.GetNormalized();
            //m10.DisplayMatrix(DataHelper.ConsoloOutput);

            //获取m11的转置矩阵
            Matrix m11 = new Matrix(4, 2, "m11");
            m11.InsertDataFromList(new List<double>() { 1, 2, 4, 7, 6, 7, 8, 7, 9, 8, 7, 15, 4, 5, 8, 8, 9, 45, 5 });
            m11.DisplayMatrix(DataHelper.ConsoloOutput);
            Matrix m12 = m11.Transpose();
            m12.DisplayMatrix(DataHelper.ConsoloOutput);

            //获取m13的转置矩阵
            Matrix m13 = new Matrix(5, 5, "m13");
            //m13.InsertDataFromList(new List<double>() { 1, -3, 3, 3, -5, 3, 6, -5, 4 }); //结果为4，(1,1,2)
            //m13.InsertDataFromList(new List<double>() { 2, 2, -2, 2, 5, -4, -2, -4, 5 }); 
            //m13.InsertDataFromList(new List<double>() {4,2,-5,6,4,-9,5,3,-7 }); //结果为1，(1,1,1)
            m13.InsertDataFromList(new List<double>
                {
                    1,
                    0.5,
                    4,
                    3,
                    3,
                    2,
                    1,
                    7,
                    5,
                    5,
                    1/4.0,
                    1/7.0,
                    1,
                    1/2.0,
                    1/3.0,
                    1/3.0,
                    1/5.0,
                    2,
                    1,
                    1,
                    1/3.0,
                    1/5.0,
                    3,
                    1,
                    1
                });
            //m13.InsertMatrix(DataHelper.ConsoloInput);
            m13.DisplayMatrix(DataHelper.ConsoloOutput);
            double eiginvalue;
            Matrix m14 = m13.Power(out eiginvalue);
            Console.WriteLine(string.Format("矩阵m14对应的最大特征值为{0}", eiginvalue));
            m14.DisplayMatrix(DataHelper.ConsoloOutput);
        }

        public static void JudgeMatrixTest()
        {
            JudgeMatrix jm1 = new JudgeMatrix(5, "测试矩阵");
            jm1.InsertDataFromList(
                new List<double>
                    {
                        1,
                        0.5,
                        4,
                        3,
                        3,
                        2,
                        1,
                        7,
                        5,
                        5,
                        1/4.0,
                        1/7.0,
                        1,
                        1/2.0,
                        1/3.0,
                        1/3.0,
                        1/5.0,
                        2,
                        1,
                        1,
                        1/3.0,
                        1/5.0,
                        3,
                        1,
                        1
                    });
            jm1.DisplayMatrix(DataHelper.ConsoloOutput);
            double eiginValue;
            var vect1 = jm1.SingleFactorWightVect(out eiginValue);
            vect1.DisplayMatrix(DataHelper.ConsoloOutput);
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
            IList<Factor> factors2 = new List<Factor>
                {
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
                    1,
                    1/2.0,
                    4,
                    3,
                    3,
                    2,
                    1,
                    7,
                    5,
                    5,
                    1/4,
                    1/7,
                    1,
                    1/2.0,
                    1/3.0,
                    1/3.0,
                    1/5.0,
                    2,
                    1,
                    1,
                    1/3.0,
                    1/5.0,
                    3,
                    1,
                    1
                });
            //加入到判断矩阵序列
            Dictionary<Factor, JudgeMatrix> level2Judges = new Dictionary<Factor, JudgeMatrix>();
            level2Judges.Add(level1.Factors[0], level2JudugeMatrix1);
            Level level2 = new Level(level1, factors2, level2Relation, level2Judges);
            //加入到模型中
            ahpModel.PushLevel(level2);

            //构造第三层次
            IList<Factor> factors3 = new List<Factor>
                {
                    new Factor("B1"),
                    new Factor("B2"),
                    new Factor("B3"),
                };
            //第三层关系矩阵
            Matrix level3Relation = new Matrix(3, 5);
            level3Relation.InsertDataFromList(new List<double>
                {
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1
                });
            //第三层判断矩阵
            JudgeMatrix level3JudugeMatrix1 = new JudgeMatrix(3);
            level3JudugeMatrix1.InsertDataFromList(new List<double>
                {
                    1,
                    2,
                    5,
                    1/2.0,
                    1,
                    2,
                    1/5.0,
                    1/2.0,
                    1
                });
            JudgeMatrix level3JudugeMatrix2 = new JudgeMatrix(3);
            level3JudugeMatrix2.InsertDataFromList(new List<double>
                {
                    1,
                    1/3.0,
                    1/8.0,
                    3,
                    1,
                    1/3.0,
                    8,
                    3,
                    1
                });
            JudgeMatrix level3JudugeMatrix3 = new JudgeMatrix(3);
            level3JudugeMatrix3.InsertDataFromList(new List<double>
                {
                    1,
                    1,
                    3,
                    1,
                    1,
                    3,
                    1/3.0,
                    1/3.0,
                    1
                });
            JudgeMatrix level3JudugeMatrix4 = new JudgeMatrix(3);
            level3JudugeMatrix4.InsertDataFromList(new List<double>
                {
                    1,
                    3,
                    4,
                    1/3.0,
                    1,
                    1,
                    1/4.0,
                    1,
                    1
                });
            JudgeMatrix level3JudugeMatrix5 = new JudgeMatrix(3);
            level3JudugeMatrix5.InsertDataFromList(new List<double>
                {
                    1,
                    1,
                    1/4.0,
                    1,
                    1,
                    1/4.0,
                    4,
                    4,
                    1
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
            ahpModel.GetLevelInfo(3).GetTotalWeightVect().DisplayMatrix(DataHelper.ConsoloOutput);
        }

        #endregion

        #region 使用控制台测试层次分析法
        public static void AhpModelSample()
        {
            //创建第一层
            Level topLevel = new Level(null,
                new List<Factor> { new Factor("Z") },
                null,
                null);
            //实例化一个AhpModel，并设置第一层对象
            AhpModel ahpModel = new AhpModel(topLevel);

            //插入一个层次，直到用户表示不再增减
            while (true)
            {
                //默认插入第二层
                InsertLevel(ahpModel);

                //然后询问是否继续插入其他层次
                var ifAddLevel = DataHelper.ReadBool("是否插入一个层次");
                if (!ifAddLevel)
                    break;
            }

            //打印层次结构模型中的相关信息
            ahpModel.DisplayModelInfo();

            //选择用以生成决策矩阵的层次
            //读入的数要-1
            int selectLevel = DataHelper.ReadValus<int>(string.Format("请从第1层到第{0}层中选择一层来创建决策矩阵", ahpModel.Levels.Count))[0] - 1;
            //选择待评价的元素
            int elementCount = DataHelper.ReadValus<int>("请问一共有多少待评价元素？")[0];
            //建立空的决策矩阵
            DecisionMatrix decisionMatrix = new DecisionMatrix(ahpModel.Levels[selectLevel].Factors, elementCount, ahpModel.Levels[selectLevel].GetTotalWeightVect(), "决策矩阵");
            //读入决策矩阵数据
            decisionMatrix.InsertMatrix(DataHelper.ConsoleArrayInput);
            //打印决策矩阵
            decisionMatrix.DisplayMatrix(DataHelper.ConsoloOutput);
            //使用改进的标准化方法处理决策矩阵
            Console.WriteLine("使用改进的归一化法对决策矩阵进行标准化法");
            ManipulateDecisionMatrix(decisionMatrix, Standardizer.ApprovedNormalize);
            //使用常规归一化法处理决策矩阵
            Console.WriteLine("使用常规的归一化法对决策矩阵进行标准化");
            ManipulateDecisionMatrix(decisionMatrix, Standardizer.Normalize);
        }

        //处理决策矩阵，打印出决策矩阵的标准化值，以及最终的决策向量
        public static void ManipulateDecisionMatrix(DecisionMatrix decisionMatrix, Standardize standardize)
        {
            //获得并打印标准化矩阵
            var standardized = decisionMatrix.GetStandardized(standardize);
            standardized.Name = "决策矩阵的标准化矩阵";
            standardized.DisplayMatrix(DataHelper.ConsoloOutput);
            //获得决策向量
            var decisionVect = decisionMatrix.GetDecisionVect(standardize);
            //打印决策结果
            decisionVect.DisplayMatrix(DataHelper.ConsoloOutput);
        }

        //为传入的AhpModel加入一个层次
        private static Level InsertLevel(AhpModel model)
        {
            //创建一个Level所必须的数据
            LevelDataModel dataModel = new LevelDataModel();

            //循环输入因素
            while (true)
            {
                foreach (var factor in GetFactors())
                {
                    dataModel.Factors.Add(factor);
                }

                var ifAddFactor = DataHelper.ReadBool("是否继续添加因素");
                if (!ifAddFactor)
                    break;
            }
            //读入并设置指标的方向
            while (true)
            {
                //首先读入一定数量的数据
                var tags = DataHelper.ReadValus<string>("请输入指标各个指标的方向，+ 代表正向，- 代表逆向", dataModel.Factors.Count);
                //表示是否获得真确的
                bool readSuccess = true;

                //依次设置Factor的正向还是逆向
                for (int i = 0; i < tags.Count; i++)
                {
                    //如果是正向，就继续，因为默认是正向
                    if (tags[i] == "+")
                        continue;
                    //如果是逆向，就设置
                    if (tags[i] == "-")
                    {
                        dataModel.Factors[i].Direction = FactorDirection.Negative;
                    }
                    //如果到这一步，说明有 +/- 以外的字符，则表示读入的数据错误，报错，并跳出循环，再重新读
                    else
                    {
                        readSuccess = false;
                        break;
                    }
                }
                if (readSuccess)
                    break;

                Console.WriteLine("输入的数据中包含无法识别的字符，请重新输入");
            }


            //输入关系矩阵
            //设置当前model中的最后一个层次为新插入层次的Parent
            dataModel.Parent = model.GetLastLevel();
            Matrix relationMatrix = new Matrix(dataModel.Factors.Count, dataModel.Parent.Factors.Count);
            Console.WriteLine("请输入关系矩阵");
            relationMatrix.InsertMatrix(DataHelper.ConsoleArrayInput);
            //relationMatrix.InsertMatrix(DataHelper.ConsoloInput);
            dataModel.RelationMatrix = relationMatrix;

            //设置判断矩阵
            Dictionary<Factor, JudgeMatrix> judgeMatrices = new Dictionary<Factor, JudgeMatrix>();
            //此处可以选择使用那种方式输入判断矩阵
            var judges = GetJudgeMatrices(relationMatrix, dataModel.Parent.Factors, dataModel.Factors);
            //var judges = GetJudgeMatrices(relationMatrix);
            for (int i = 0; i < relationMatrix.Y; i++)
            {
                judgeMatrices.Add(model.GetLastLevel().Factors[i], judges[i]);
            }
            dataModel.JudgeMatrices = judgeMatrices;

            //创建一个新的层次，并加入层次结构模型中
            Level newLevel = new Level(dataModel);
            model.PushLevel(newLevel);

            return model.GetLastLevel();
        }

        //获取Factor
        public static IList<Factor> GetFactors()
        {
            var names = DataHelper.ReadValus<string>("请输入因素的名称，以空格分隔");
            IList<Factor> factors = new List<Factor>();
            foreach (var name in names)
            {
                factors.Add(new Factor(name));
            }
            return factors;
        }

        //根据关系矩阵构造判断矩阵
        public static IList<JudgeMatrix> GetJudgeMatrices(Matrix relationMatrix)
        {
            IList<JudgeMatrix> judgeMatrices = new List<JudgeMatrix>();
            for (int j = 0; j < relationMatrix.Y; j++)
            {
                var affectcount = 0;
                for (int i = 0; i < relationMatrix.X; i++)
                {
                    if (Math.Abs(relationMatrix[i, j] - 0) > 0.00001)
                        affectcount++;
                }
                JudgeMatrix judgeMatrix = new JudgeMatrix(affectcount);
                //可以选择判断矩阵的构造方式
                judgeMatrix.InsertMatrix(DataHelper.ConsoleArrayInput);
                judgeMatrices.Add(judgeMatrix);
            }
            return judgeMatrices;
        }

        //使用改进的方法构造判断矩阵
        public static IList<JudgeMatrix> GetJudgeMatrices(Matrix relationMatrix, IList<Factor> parentFactors, IList<Factor> currentFacors)
        {
            IList<JudgeMatrix> judgeMatrices = new List<JudgeMatrix>();

            //按照上一层中的各个因素逐个处理
            for (int j = 0; j < relationMatrix.Y; j++)
            {
                //获得上层某因素影响的下层因素
                IList<Factor> affectedFactors = new List<Factor>();
                for (int i = 0; i < relationMatrix.X; i++)
                {
                    if (Math.Abs(relationMatrix[i, j] - 0) > 0.00001)
                        affectedFactors.Add(currentFacors[i]);
                }
                //构造一个空的判断矩阵，
                int affectedCount = affectedFactors.Count;
                JudgeMatrix judgeMatrix = new JudgeMatrix(affectedCount);

                #region 然后使用改进的构造方法构造判断矩阵

                //打印提示信息
                Console.WriteLine("请输入因素{0}影响的{1}个因素的重要性排序，\n同时给出最重要与最不重要的因素比率", parentFactors[j].Name, affectedCount);
                Console.Write("被影响的因素包括：");
                for (int i = 0; i < affectedCount; i++)
                {
                    Console.Write("{0} {1}，", i, affectedFactors[i].Name);
                }
                Console.WriteLine();
                //各个专家给出的排序的表
                IList<IList<int>> rateTable = new List<IList<int>>();
                IList<int> pList = new List<int>();
                //表示第几个专家给出的排序
                int rateCount = 0;
                //循环读取专家的建议排序，然后放入rateTable中
                while (true)
                {
                    rateCount++;
                    //获取排序
                    var readRate = DataHelper.ReadValus<int>(string.Format("请输入第{0}个专家的排序，从0开始！", rateCount), affectedCount);
                    rateTable.Add(readRate);
                    //获取p
                    int p = DataHelper.ReadValus<int>(string.Format("请输入第{0}个专家的的最重要与最不重要的因素比率", rateCount), 1)[0];
                    pList.Add(p);
                    //是否继续添加，如果不添加了，就跳出
                    if (!DataHelper.ReadBool("是否要继续添加重要性排序？"))
                        break;
                }
                //计算根据rateTable和pList构造判断矩阵
                double pAvg = pList.Average();
                IList<double> aList = new List<double>();
                //对被影响的因素逐个处理，生成各个被影响因素的平均赋权值
                for (int i = 0; i < affectedCount; i++)
                {
                    int sumIndex = 0, avgIndex = 0, pow = 0;
                    for (int k = 0; k < rateCount; k++)
                    {
                        sumIndex += (rateTable[k].IndexOf(i) + 1);
                    }
                    avgIndex = sumIndex / rateCount;
                    pow = affectedCount - avgIndex + 1;
                    aList.Add(pow);
                }
                //对判断矩阵逐个处理插入值
                for (int m = 0; m < affectedCount; ++m)
                {
                    for (int n = 0; n < affectedCount; ++n)
                    {
                        if (aList[m] >= aList[n])
                        {
                            var numerator = aList[m] - aList[n];
                            var denominator = aList.Max() - aList.Min();
                            judgeMatrix[m, n] = numerator / denominator * (pAvg - 1) + 1;
                        }
                        else
                        {
                            var numerator = aList[n] - aList[m];
                            var denominator = aList.Max() - aList.Min();
                            judgeMatrix[m, n] = 1 / (numerator / denominator * (pAvg - 1) + 1);
                        }
                    }
                }
                #endregion

                judgeMatrices.Add(judgeMatrix);
            }

            return judgeMatrices;
        }

        //打印出AhpModel的基本信息
        //private static void DisplayInfoOfAhpModel(AhpModel model)
        //{
        //    Console.WriteLine("************以下是层次结构模型的主要信息*************");
        //    for (int i = 0; i < model.Levels.Count; i++)
        //    {
        //        if (i > 0)
        //        {
        //            var level = model.GetLevelInfo(i);
        //            foreach (var judgeMatrix in level.JudgeMatrices)
        //            {
        //                Console.WriteLine("{0}的判断矩阵", judgeMatrix.Key.Name);
        //                judgeMatrix.Value.DisplayMatrix(DataHelper.ConsoloOutput);
        //            }
        //            level.GetTotalWeightVect().DisplayMatrix(DataHelper.ConsoloOutput);
        //            Console.WriteLine("CI={0},RI={1},CR={2}", level.LevelCI, level.LevelRI, level.LevelCR);
        //        }
        //        else
        //        {
        //            Console.WriteLine("顶层木有数据%>_<%");
        //        }
        //        Console.WriteLine("-------------------第{0}层---------------------", i + 1);
        //    }
        //}
        #endregion

    }
}
