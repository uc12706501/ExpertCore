using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AHP.Core;

namespace ExpertChooseCore
{
    internal class AhpModelFileTester
    {
        private string _inputFile = "D:\\SourceCode\\Projects\\ExpertCore\\input.txt";
        private string _outputFile = "D:\\SourceCode\\Projects\\ExpertCore\\output.txt";
        private int _cursor = 0;
        private IList<string> _contents;

        public AhpModelFileTester(string inputFile, string outputFile)
        {
            _inputFile = inputFile;
            _outputFile = outputFile;
            Init();
        }

        public AhpModelFileTester()
        {
            Init();
        }

        //初始化
        private void Init()
        {
            //将input.txt的所有内容都读入contents中
            var contents = File.ReadLines(_inputFile);
            foreach (var content in contents)
            {
                _contents.Add(content);
            }

            //清空ouput.txt
            if (File.Exists(_outputFile))
            {
                File.Delete(_outputFile);
                var newOutputFile = File.Create(_outputFile);
                newOutputFile.Close();
            }
        }

        public void Run()
        {
            AhpModel ahpModel = InitialAhpModel();

            #region TODO

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

            #endregion

        }

        #region TODO
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
        #endregion


        //初始化AHP模型
        private AhpModel InitialAhpModel()
        {
            //创建第一层
            Level topLevel = new Level(null,
                new List<Factor> { new Factor("Z") },
                null,
                null);
            //实例化一个AhpModel，并设置第一层对象
            return new AhpModel(topLevel);
        }

        private void AddLevels(AhpModel model)
        {
            for (int i = 0; i < 2; i++)
            {
                AddLevel(model);
            }
        }

        private void AddLevel(AhpModel model)
        {
            var names = ReadNextLine().Split(' ');
            var directions = ReadNextLine().Split(' ');
            var relationData = ConvertTo<double>(ReadNextLine());
            //判断是否使用改进的方法进行构造
            bool improved = ReadNextLine().Equals("a");

            LevelDataModel dataModel = GenerateLevelDataModel(names, directions);
            var relationMatrix = SetRelationMatrix(model, dataModel, relationData);

            SetJudgeMatrices(model, relationMatrix, dataModel);

        }

        //根据因素名和方向字符串创建层次数据模型
        private LevelDataModel GenerateLevelDataModel(IList<string> names, IList<string> directions)
        {
            LevelDataModel dataModel = new LevelDataModel();
            for (int i = 0; i < names.Count; i++)
            {
                dataModel.Factors.Add(new Factor(names[i]));
                //如果是"-"，就设置为逆向
                if (directions[i].Equals("-"))
                {
                    dataModel.Factors[i].Direction = FactorDirection.Negative;
                }
                //如果是数值，这设置为中间最大
                double temp;
                if (Double.TryParse(directions[i], out temp))
                {
                    dataModel.Factors[i].Direction = FactorDirection.Middle;
                    dataModel.Factors[i].MaxValue = temp;
                }
            }

            return dataModel;
        }

        //设置某一层和上一层的关系矩阵
        private Matrix SetRelationMatrix(AhpModel model, LevelDataModel dataModel, IList<double> relationData)
        {
            //输入关系矩阵
            //设置当前model中的最后一个层次为新插入层次的Parent
            dataModel.Parent = model.GetLastLevel();
            Matrix relationMatrix = new Matrix(dataModel.Factors.Count, dataModel.Parent.Factors.Count);
            relationMatrix.InsertDataFromList(relationData);
            //relationMatrix.InsertMatrix(DataHelper.ConsoloInput);
            dataModel.RelationMatrix = relationMatrix;
            return relationMatrix;
        }

        //构造判断矩阵列
        private void SetJudgeMatrices(AhpModel model, Matrix relationMatrix, LevelDataModel dataModel)
        {
            //存储判断矩阵
            Dictionary<Factor, JudgeMatrix> judgeMatrices = new Dictionary<Factor, JudgeMatrix>();
            //此处可以选择使用那种方式输入判断矩阵
            var judges = GetJudgeMatricesImproved(relationMatrix, dataModel.Parent.Factors, dataModel.Factors);

            for (int i = 0; i < relationMatrix.Y; i++)
            {
                judgeMatrices.Add(model.GetLastLevel().Factors[i], judges[i]);
            }
            dataModel.JudgeMatrices = judgeMatrices;

            //创建一个新的层次，并加入层次结构模型中
            Level newLevel = new Level(dataModel);
            model.PushLevel(newLevel);
        }

        //直接输入判断矩阵
        private IList<JudgeMatrix> GetJudgeMatricesNormal(Matrix relationMatrix, IList<Factor> parentFactors,
            IList<Factor> currentFacors)
        {
            return null;
        }

        //改进构造判断矩阵
        private IList<JudgeMatrix> GetJudgeMatricesImproved(Matrix relationMatrix, IList<Factor> parentFactors,
            IList<Factor> currentFacors)
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

                //各个专家给出的排序的表
                IList<IList<int>> rateTable = new List<IList<int>>();
                IList<int> pList = new List<int>();
                //表示第几个专家给出的排序
                int rateCount = 0;
                //循环读取专家的建议排序，然后放入rateTable中

                rateCount++;
                //获取排序
                var readRate = ConvertTo<int>(ReadNextLine());
                rateTable.Add(readRate);
                //获取p
                int p = DataHelper.ReadValus<int>(ReadNextLine())[0];
                pList.Add(p);


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


        //读取游标所指向的当前行，读完之后游标指向下一行
        private string ReadNextLine()
        {
            return _contents[_cursor++];
        }

        //将输入的字符串按照空格分隔之后，转换成对应的T列表
        public IList<T> ConvertTo<T>(string content)
        {
            IEnumerable<string> values = content.Split(' ');
            IList<T> trueValues = new List<T>();
            foreach (var value in values)
            {
                trueValues.Add((T)Convert.ChangeType(value, typeof(T)));
            }
            return trueValues;
        }
    }
}
