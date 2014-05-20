using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AHP.Core;

namespace ExpertChooseSystem
{
    public partial class MainWindow : Form
    {
        //层次结构模型
        private AhpModel _ahpModel;
        //决策矩阵
        private DecisionMatrix _decisionMatrix;

        //构造函数
        public MainWindow()
        {
            InitializeComponent();
            //初始化层次结构模型
            InitModel();
            //初始化决策矩阵
            _decisionMatrix = new DecisionMatrix(_ahpModel.Levels[2], 0);
        }

        private void dcsSetBtn_Click(object sender, EventArgs e)
        {
            DecisionMatrixForm decisionMatrixForm = new DecisionMatrixForm(_decisionMatrix);
            decisionMatrixForm.SaveEvent += OnDcsMatrixUpdate;
            decisionMatrixForm.ShowDialog();
        }

        /// <summary>
        /// 初始化决策模型
        /// </summary>
        private void InitModel()
        {
            //创建第一层
            Factor factor = new Factor("Z");
            Level toplevel = new Level(null, new List<Factor>() { factor }, null, null);
            //设置初始化的模型
            _ahpModel = new AhpModel(toplevel);

            //构造第二层
            //第二层因素
            IList<Factor> factors2 = new List<Factor>
                {
                    new Factor("A1"),
                    new Factor("A2"),
                    new Factor("A3"),
                    new Factor("A4"),
                };
            //第二层关系矩阵
            Matrix level2Relation = new Matrix(4, 1);
            level2Relation.InsertDataFromList(new List<double> { 1, 1, 1, 1 });
            //第二层判断矩阵，初始化为空
            JudgeMatrix level2JudugeMatrix1 = new JudgeMatrix(4);
            //加入到判断矩阵序列
            Dictionary<Factor, JudgeMatrix> level2Judges = new Dictionary<Factor, JudgeMatrix>();
            level2Judges.Add(toplevel.Factors[0], level2JudugeMatrix1);
            Level level2 = new Level(toplevel, factors2, level2Relation, level2Judges);
            //加入到模型中
            _ahpModel.PushLevel(level2);

            //构造第三层次
            IList<Factor> factors3 = new List<Factor>
                {
                    new Factor("B1"),
                    new Factor("B2"),
                    new Factor("B3"),
                    new Factor("B4"),
                    new Factor("B5"),
                    new Factor("B6"),
                    new Factor("B7"),
                    new Factor("B8"),
                    new Factor("B9"),
                    new Factor("B10"),
                    new Factor("B11"),
                    new Factor("B12"),
                    new Factor("B13"),
                    new Factor("B14"),
                };
            //第三层关系矩阵
            Matrix level3Relation = new Matrix(3, 5);
            level3Relation.InsertDataFromList(new List<double>
                {
                    1,0,0,0,1,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1
                });
            //第三层判断矩阵
            JudgeMatrix level3JudugeMatrix1 = new JudgeMatrix(3);
            JudgeMatrix level3JudugeMatrix2 = new JudgeMatrix(5);
            JudgeMatrix level3JudugeMatrix3 = new JudgeMatrix(3);
            JudgeMatrix level3JudugeMatrix4 = new JudgeMatrix(4);
            //加入到判断矩阵序列
            Dictionary<Factor, JudgeMatrix> level3Judges = new Dictionary<Factor, JudgeMatrix>();
            level3Judges.Add(level2.Factors[0], level3JudugeMatrix1);
            level3Judges.Add(level2.Factors[1], level3JudugeMatrix2);
            level3Judges.Add(level2.Factors[2], level3JudugeMatrix3);
            level3Judges.Add(level2.Factors[3], level3JudugeMatrix4);
            Level level3 = new Level(level2, factors3, level3Relation, level3Judges);
            //加入到模型中
            _ahpModel.PushLevel(level3);
        }

        //显示测试信息
        private void testBtn_Click(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();
            for (int i = 0; i < _decisionMatrix.X; i++)
            {
                message.Append(_decisionMatrix[i, 0]);
                message.Append("\n");
            }
            MessageBox.Show(message.ToString());
        }

        //响应决策矩阵的修改
        private void OnDcsMatrixUpdate(DecisionMatrix decisionMatrix)
        {
            _decisionMatrix = decisionMatrix;
        }
    }
}
