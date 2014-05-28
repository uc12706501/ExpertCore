using System;
using System.Collections;
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
    public partial class DecisionMatrixForm : Form
    {
        private IList<ExpertModel> _experts;
        private DecisionMatrix _decisionMatrix;

        #region 构造函数

        public DecisionMatrixForm(DecisionMatrix decisionMatrix)
        {
            InitializeComponent();
            //将决策矩阵中的数据转化为专家列表
            _decisionMatrix = decisionMatrix;
            _experts = decisionMatrix.ToExpertList();
            dataGrid.DataSource = _experts;
        }

        private DecisionMatrixForm()
        {
            InitializeComponent();
        }

        #endregion

        //专家添加按钮
        private void expertAddBtn_Click(object sender, EventArgs e)
        {
            _experts.Add(new ExpertModel());
            //更新数据表
            RefreshGridDataSource();
        }

        //专家移除按钮
        private void expertRmvBtn_Click(object sender, EventArgs e)
        {
            //弹出对话框进行确认
            DialogResult dlResult = MessageBox.Show(this, "要删除这些记录吗？", "请确认",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
            //如果确认了，则执行删除操作
            if (dlResult == DialogResult.Yes)
            {
                int j = dataGrid.SelectedRows.Count;
                int[] l = new int[j];

                int i;
                for (i = 0; i < j; i++)
                {
                    l[i] = dataGrid.SelectedRows[i].Index;
                }
                foreach (var i1 in l)
                {
                    _experts.RemoveAt(i1);
                }
                //刷新数据
                RefreshGridDataSource();
            }
        }

        //保存按钮
        //只能在这里修改决策矩阵！！
        private void saveBtn_Click(object sender, EventArgs e)
        {
            _decisionMatrix = _decisionMatrix.SetDecisionMatrix(_experts);
            DecisionMatrixSave(_decisionMatrix);
            Close();
        }

        //取消按钮
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        //更新数据表
        private void RefreshGridDataSource()
        {
            dataGrid.DataSource = null;
            dataGrid.DataSource = _experts;
        }

        //插入测试数据
        private void insertTestData_Click(object sender, EventArgs e)
        {
            _experts.Add(new ExpertModel(45, 91, 90, 11, 57, 68, 56, 0, 81, 80, 0.68, 0.81, 0.98, 0.98));
            _experts.Add(new ExpertModel(50, 82, 90, 16, 68, 79, 67, 0, 91, 93, 0.71, 0.83, 1, 0.95));
            _experts.Add(new ExpertModel(52, 93, 90, 14, 90, 84, 89, 1, 89, 90, 0.83, 0.84, 0.85, 0.85));
            _experts.Add(new ExpertModel(38, 82, 70, 9, 59, 73, 57, 2, 84, 80, 0.62, 0.75, 0.87, 0.92));
            _experts.Add(new ExpertModel(66, 71, 90, 21, 49, 83, 86, 0, 78, 81, 0.78, 0.90, 0.82, 0.88));
            
            RefreshGridDataSource();
        }

        public event DecisionMatrixSaveHandler DecisionMatrixSave;
    }
}
