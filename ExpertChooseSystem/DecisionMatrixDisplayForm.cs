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
    public partial class DecisionMatrixDisplayForm : Form
    {
        private AhpModel _ahpModel;
        private DecisionMatrix _decisionMatrix;
        private Standardize _standardize;

        #region 构造函数

        public DecisionMatrixDisplayForm(DecisionMatrix decisionMatrix, Standardize standardize)
            : this()
        {
            _decisionMatrix = decisionMatrix;
            _standardize = standardize;
            Init();
        }

        private DecisionMatrixDisplayForm()
        {
            InitializeComponent();
        }

        #endregion

        //执行一些初始化操作
        private void Init()
        {
            //显示决策矩阵
            DataGridView decisionMatrixGrid = new DataGridView()
                {
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                    Width = 700,
                    ReadOnly = true,
                };
            decisionMatrixGrid.DataSource = _decisionMatrix.ToExpertList();
            panel3.Controls.Add(decisionMatrixGrid);

            //显示标准化矩阵
            DataGridView standardizeMatrixGrid = new DataGridView()
            {
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                Width = 700,
                ReadOnly = true

            };
            //设置显示格式
            standardizeMatrixGrid.CellFormatting += (sender, e) =>
                {
                    //不处理新建行
                    if (e.RowIndex != standardizeMatrixGrid.NewRowIndex)
                    {
                        double d = double.Parse(e.Value.ToString());
                        e.Value = d.ToString("N3");
                    }
                };

            var standizedMatrix = _decisionMatrix.GetStandardized(_standardize);
            standardizeMatrixGrid.DataSource = standizedMatrix.ToExpertList();
            panel4.Controls.Add(standardizeMatrixGrid);

            //初始化决策向量的显示
            var decisionVect = _decisionMatrix.GetDecisionVect(_standardize);
            //将决策矩阵显示出来
            DataGridView decisionVectGrid = new DataGridView()
            {
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                ReadOnly = true
            };
            //设置显示格式
            decisionVectGrid.CellFormatting += (sender, e) =>
            {
                //不处理新建行
                if (e.RowIndex != decisionVectGrid.NewRowIndex)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("N3");
                }
            };


            decisionVectGrid.Columns.Add("Total", "总得分");
            for (int i = 0; i < _decisionMatrix.X; i++)
            {
                object[] value = new object[] { decisionVect[i, 0] };
                decisionVectGrid.Rows.Add(value);
            }
            panel1.Controls.Add(decisionVectGrid);

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
