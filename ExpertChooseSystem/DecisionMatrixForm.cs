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

        public event DecisionMatrixSaveHandler DecisionMatrixSave;
    }

    public class A
    {
        public double B { get; set; }
    }

}
