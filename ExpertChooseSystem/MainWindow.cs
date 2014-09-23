using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExpertChoose.AHP.Core;

namespace ExpertChoose.AHP.WinformSystem
{
    public partial class MainWindow : Form
    {
        //层次结构模型
        private AhpModel _ahpModel;
        //决策矩阵
        private DecisionMatrix _decisionMatrix;
        //判断矩阵集合
        private IList<JudgeMatrixPair> _judgeMatrixPairs;
        //指示是否使用改造的方法
        private bool isApproved;
        //构造函数
        public MainWindow()
        {
            InitializeComponent();
            //默认不使用改进的方式
            isApproved = false;
            judgeMatrixSwitchBtn.Text = "常规构造";

            //初始化层次结构模型
            InitModel();
            //初始化决策矩阵
            _decisionMatrix = new DecisionMatrix(_ahpModel.Levels[2], 0);
            //初始化判断矩阵
            InitJudgeMatrixPairs();
            //更新模型中的判断矩阵
            UpdateJudgeMatrix();
        }

        private void dcsSetBtn_Click(object sender, EventArgs e)
        {
            //运行到这一步说明模型中所有的判断矩阵都符合要求
            DecisionMatrixForm decisionMatrixForm = new DecisionMatrixForm(_decisionMatrix);
            decisionMatrixForm.DecisionMatrixSave += OnDcsMatrixUpdate;
            decisionMatrixForm.ShowDialog();
        }

        #region 初始化操作

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
                    new Factor("B1"){Direction = FactorDirection.Negative},
                    new Factor("B2"),
                    new Factor("B3"),
                    new Factor("B4"),
                    new Factor("B5"),
                    new Factor("B6"),
                    new Factor("B7"),
                    new Factor("B8"){Direction = FactorDirection.Negative},
                    new Factor("B9"),
                    new Factor("B10"),
                    new Factor("B11"),
                    new Factor("B12"),
                    new Factor("B13"),
                    new Factor("B14"),
                };
            //第三层关系矩阵
            Matrix level3Relation = new Matrix(14, 4);
            level3Relation.InsertDataFromList(new List<double>
                {
                    1,
                    0,
                    0,
                    0,
                    1,
                    0,
                    0,
                    0,
                    1,
                    0,
                    0,
                    0,
                    0,
                    1,
                    0,
                    0,
                    0,
                    1,
                    0,
                    0,
                    0,
                    1,
                    0,
                    0,
                    0,
                    1,
                    0,
                    0,
                    0,
                    0,
                    1,
                    0,
                    0,
                    0,
                    1,
                    0,
                    0,
                    0,
                    1,
                    0,
                    0,
                    0,
                    0,
                    1,
                    0,
                    0,
                    0,
                    1,
                    0,
                    0,
                    0,
                    1,
                    0,
                    0,
                    0,
                    1
                });
            //第三层判断矩阵
            JudgeMatrix level3JudugeMatrix1 = new JudgeMatrix(3);
            JudgeMatrix level3JudugeMatrix2 = new JudgeMatrix(4);
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

        private void InitJudgeMatrixPairs()
        {
            _judgeMatrixPairs = new List<JudgeMatrixPair>()
                {
                    new JudgeMatrixPair()
                        {
                            AffectedFactor = _ahpModel.Levels[0].Factors[0],
                            NormalGen = new JudgeMatrix(4),
                            ApprovedGen = new JudgeMatrix(4),
                            SubFactors = _ahpModel.Levels[1].GetAffectFactor(_ahpModel.Levels[0].Factors[0])
                        },
                    new JudgeMatrixPair()
                        {
                            AffectedFactor = _ahpModel.Levels[1].Factors[0],
                            NormalGen = new JudgeMatrix(3),
                            ApprovedGen = new JudgeMatrix(3),
                            SubFactors = _ahpModel.Levels[2].GetAffectFactor(_ahpModel.Levels[1].Factors[0])
                        },
                    new JudgeMatrixPair()
                        {
                            AffectedFactor = _ahpModel.Levels[1].Factors[1],
                            NormalGen = new JudgeMatrix(4),
                            ApprovedGen = new JudgeMatrix(4),
                            SubFactors = _ahpModel.Levels[2].GetAffectFactor(_ahpModel.Levels[1].Factors[1])
                        },
                    new JudgeMatrixPair()
                        {
                            AffectedFactor = _ahpModel.Levels[1].Factors[2],
                            NormalGen = new JudgeMatrix(3),
                            ApprovedGen = new JudgeMatrix(3),
                            SubFactors = _ahpModel.Levels[2].GetAffectFactor(_ahpModel.Levels[1].Factors[2])
                        },
                    new JudgeMatrixPair()
                        {
                            AffectedFactor = _ahpModel.Levels[1].Factors[3],
                            NormalGen = new JudgeMatrix(4),
                            ApprovedGen = new JudgeMatrix(4),
                            SubFactors = _ahpModel.Levels[2].GetAffectFactor(_ahpModel.Levels[1].Factors[3])
                        },
                };
        }

        #endregion

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

        //label的单击处理事件
        private void InfoLabelClick(object sender, EventArgs e)
        {
            try
            {
                Label label = sender as Label;
                var factor = GetFactorByLabelName(label.Name);
                var judgeMatrix = GetJudgeMatrix(factor);
                //验证判断矩阵是否有效
                judgeMatrix.CheckJudgeMatrix();
                JudgeMatrixDisplayForm judgeMatrixDisplayForm = new JudgeMatrixDisplayForm(judgeMatrix);
                judgeMatrixDisplayForm.ShowDialog();
            }
            catch (JudgeMatrixInvalidException exception)
            {
                MessageBox.Show("您还没有设置判断矩阵，或者设置的判断矩阵无效，请先修改！");
            }

        }

        //点击创建判断矩阵
        private void JudgeMatrixButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            var factor = GetFacotrByButtonName(button.Name);
            var judgeMatrixPair = _judgeMatrixPairs.Single(x => x.AffectedFactor == factor);
            //如果确认了，则使用改进的方法
            if (isApproved)
            {
                ApprovedGenForm approvedGenForm = new ApprovedGenForm(judgeMatrixPair);
                approvedGenForm.JudgeMatrixSave += OnJudgeMatrixGenFinish;
                approvedGenForm.ShowDialog();
            }
            //否则使用常规方法
            else
            {
                NormalGenFrom normalGenFrom = new NormalGenFrom(judgeMatrixPair);
                normalGenFrom.JudgeMatrixSave += OnJudgeMatrixGenFinish;
                normalGenFrom.ShowDialog();
            }
        }

        //点击显示层次信息
        private void LevelInfoButtonClick(object sender, EventArgs e)
        {
            try
            {
                Button button = sender as Button;
                Level level = GetLevelByButtonName(button.Name);
                level.CheckJudgeMatrices();
                LevelDisplayForm levelDisplayForm = new LevelDisplayForm(level);
                levelDisplayForm.ShowDialog();
            }
            catch (LevelJudgeMatrixInvaliException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //使用归一化法进行标准化处理，打印相关信息
        private void GetDcsBtnClick(object sender, EventArgs e)
        {
            if (_decisionMatrix.X<1)
            {
                MessageBox.Show("决策矩阵中没有数据，请先输入决策数据！");
                return;
            }
            try
            {
                //首先必须检测层次结构模型中的各个判断矩阵是否构造完成
                _ahpModel.Levels[2].CheckJudgeMatrices();

                var button = sender as Button;
                DecisionMatrixDisplayForm displayForm;
                if (button.Name == "getDcsBtn1")
                    displayForm = new DecisionMatrixDisplayForm(_decisionMatrix, Standardizer.Normalize);
                else
                    displayForm = new DecisionMatrixDisplayForm(_decisionMatrix, Standardizer.ApprovedNormalize);

                displayForm.Show();
            }
            catch (LevelJudgeMatrixInvaliException ex)
            {
                string message = string.Format("层次结构模型构造不符合计算要求\n{0}", ex.Message);
                MessageBox.Show(message);
            }
        }

        //切换当前的模式
        private void judgeMatrixSwitchBtn_Click(object sender, EventArgs e)
        {
            isApproved = !isApproved;
            judgeMatrixSwitchBtn.Text = isApproved ? "改进构造" : "常规构造";
            //每次切换之后都需要刷新模型中的判断矩阵
            UpdateJudgeMatrix();
        }

        //根据被影响因素和当前的模式，返回判断矩阵
        private JudgeMatrix GetJudgeMatrix(Factor factor)
        {
            if (isApproved)
                return _judgeMatrixPairs.Single(x => x.AffectedFactor == factor).ApprovedGen;
            return _judgeMatrixPairs.Single(x => x.AffectedFactor == factor).NormalGen;
        }

        #region 根据控件的名称，返回操作的对象

        private Factor GetFacotrByButtonName(string buttonName)
        {
            switch (buttonName)
            {
                case "judgeBtnZ":
                    return _ahpModel.Levels[0].Factors[0];
                case "judgeBtnA1":
                    return _ahpModel.Levels[1].Factors[0];
                case "judgeBtnA2":
                    return _ahpModel.Levels[1].Factors[1];
                case "judgeBtnA3":
                    return _ahpModel.Levels[1].Factors[2];
                case "judgeBtnA4":
                    return _ahpModel.Levels[1].Factors[3];
                default:
                    return null;
            }
        }

        private Factor GetFactorByLabelName(string labelName)
        {
            switch (labelName)
            {
                case "labelZ":
                    return _ahpModel.Levels[0].Factors[0];
                case "labelA1":
                    return _ahpModel.Levels[1].Factors[0];
                case "labelA2":
                    return _ahpModel.Levels[1].Factors[1];
                case "labelA3":
                    return _ahpModel.Levels[1].Factors[2];
                case "labelA4":
                    return _ahpModel.Levels[1].Factors[3];
                default:
                    return null;
            }
        }

        private Level GetLevelByButtonName(string buttonName)
        {
            switch (buttonName)
            {
                case "levelInfoBtn1":
                    return _ahpModel.Levels[1];
                case "levelInfoBtn2":
                    return _ahpModel.Levels[2];
                default:
                    return null;
            }

        }

        #endregion

        //更新model中所有的判断矩阵
        private void UpdateJudgeMatrix()
        {
            //更新第一层的判断矩阵
            _judgeMatrixPairs.SetJudgeMatrices(_ahpModel.Levels[1], isApproved);
            //更新第二层的判断矩阵
            _judgeMatrixPairs.SetJudgeMatrices(_ahpModel.Levels[2], isApproved);
        }

        #region 事件处理函数

        //响应决策矩阵的修改
        private void OnDcsMatrixUpdate(DecisionMatrix decisionMatrix)
        {
            _decisionMatrix = decisionMatrix;
        }

        //响应常规判断矩阵构造完成时间
        private void OnJudgeMatrixGenFinish(JudgeMatrixPair judgeMatrixPair)
        {
            var thePair = _judgeMatrixPairs.Single(x => x.AffectedFactor == judgeMatrixPair.AffectedFactor);
            thePair.ApprovedGen = judgeMatrixPair.ApprovedGen;
            thePair.NormalGen = judgeMatrixPair.NormalGen;
            UpdateJudgeMatrix();
        }
        #endregion

    }
}
