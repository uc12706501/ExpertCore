using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExpertChooseSystem
{
    public partial class NormalGenFrom : Form
    {
        #region 事件及其处理函数的调用

        public event JudgeMatrixSaveHandler JudgeMatrixSave;

        protected virtual void OnJudgeMatrixSave(JudgeMatrixPair judgematrixpair)
        {
            JudgeMatrixSaveHandler handler = JudgeMatrixSave;
            if (handler != null) handler(judgematrixpair);
        }

        #endregion

        private JudgeMatrixPair _judgeMatrixPair;

        #region 构造函数

        public NormalGenFrom(JudgeMatrixPair judgeMatrixPair)
            : this()
        {
            _judgeMatrixPair = judgeMatrixPair;
            InitGrid(judgeMatrixPair);
        }

        private NormalGenFrom()
        {
            InitializeComponent();
        }

        #endregion

        //初始化判断矩阵表格
        private void InitGrid(JudgeMatrixPair judgeMatrixPair)
        {
            //生成一个空的表格
            int n = judgeMatrixPair.NormalGen.X;
            for (int i = 0; i < n; i++)
            {
                dataGrid.Columns.Add("column" + i.ToString(), i.ToString());
            }
            dataGrid.Rows.Add(n);
            //填充数据
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGrid.Rows[i].Cells[j].Value = judgeMatrixPair.NormalGen[i, j];
                }
            }
        }

        //点击保存按钮
        private void saveBtn_Click(object sender, EventArgs e)
        {
            //将数据读取到矩阵中
            ReadDataToMatrix();
            OnJudgeMatrixSave(_judgeMatrixPair);
            Close();
        }

        //将表格中的数据读取到判断矩阵中
        private void ReadDataToMatrix()
        {
            int n = _judgeMatrixPair.NormalGen.X;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double temp = double.Parse(dataGrid.Rows[i].Cells[j].Value.ToString());
                    _judgeMatrixPair.NormalGen[i, j] = temp;
                }
            }
        }

        //点击取消按钮
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
