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
    public partial class JudgeMatrixDisplayForm : Form
    {
        #region 字段和构造函数

        private JudgeMatrix _judgeMatrix;

        public JudgeMatrixDisplayForm(JudgeMatrix judgeMatrix)
            : this()
        {
            _judgeMatrix = judgeMatrix;
            Init();
        }

        private JudgeMatrixDisplayForm()
        {
            InitializeComponent();
        }

        #endregion

        //执行初始化操作
        private void Init()
        {
            //显示判断矩阵
            DataGridView dgv = new DataGridView()
                {
                    ReadOnly = true,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                };
            //格式化输出
            dgv.CellFormatting += (sender, e) =>
            {
                //不处理新建行
                if (e.RowIndex != dgv.NewRowIndex)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("N3");
                }
            };
            dgv.DataSource = _judgeMatrix.ToDataTable();
            judgeMatrixPanel.Controls.Add(dgv);

            //显示层次单排序权重
            var singleSortVect = _judgeMatrix.SingleFactorWightVect().Transpose();
            DataGridView dgv1 = new DataGridView()
            {
                Height = 100,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
            };
            //对数据进行格式化输出
            dgv1.CellFormatting += (sender, e) =>
            {
                //不处理新建行
                if (e.RowIndex != dgv1.NewRowIndex)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("N3");
                }
            };

            dgv1.DataSource = singleSortVect.ToDataTable();
            wightVectPanel.Controls.Add(dgv1);

            //设置标签信息
            ciLabel.Text = string.Format("CI={0:f4}", _judgeMatrix.CI);
            crLabel.Text = string.Format("CR={0:f4}", _judgeMatrix.CR);
            riLabel.Text = string.Format("RI={0:f4}", _judgeMatrix.RI);
        }
    }
}
