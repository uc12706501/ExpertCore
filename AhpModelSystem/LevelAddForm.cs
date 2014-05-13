using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AHP.Core;

namespace AhpModelSystem
{
    public partial class LevelAddForm : Form
    {
        private AhpModel ahpModel;
        private IList<Factor> _factors;
        private Matrix _relatrionMatrix;
        private Dictionary<Factor, JudgeMatrix> judgeMatrices; 

        private LevelAddForm()
        {
            InitializeComponent();
        }

        //构造函数，传入需要处理的层级结构模型
        public LevelAddForm(AhpModel model)
            : this()
        {
            ahpModel = model;
        }

        private void LevelAddForm_Load(object sender, EventArgs e)
        {
            //如何设置TableLayoutPanel的行的高度
            //tableLayoutPanel1.RowStyles[1].SizeType=SizeType.Absolute;
            //tableLayoutPanel1.RowStyles[1].Height = 33;
            AutoSize = true;
            tableLayoutPanel1.AutoSize = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //弹出添加因素窗口
        private void addFactorButton_Click(object sender, EventArgs e)
        {

        }

        //添加关系矩阵
        private void addRelationButton_Click(object sender, EventArgs e)
        {

        }


    }
}
