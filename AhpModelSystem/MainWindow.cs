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
    public partial class MainWindow : Form
    {
        //层次结构模型
        private AhpModel ahpModel;

        public AhpModel AhpModel
        {
            get { return ahpModel; }
            set { ahpModel = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            InitModel();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AutoSize = true;
            contentTable.AutoSize = true;
            LoadContent();
        }

        /// <summary>
        /// 载入层次结构模型内容
        /// </summary>
        private void LoadContent()
        {
            int count = 0;
            foreach (var level in ahpModel.Levels)
            {
                //设置第一列
                Label levelLab = new Label()
                {
                    Text = String.Format("第{0}层", count),
                    Anchor = AnchorStyles.Left
                };
                contentTable.Controls.Add(levelLab, 0, count);
                //设置第二列
                for (int i = 0; i < level.FactorCount; i++)
                {
                    Label factorLab = new Label()
                    {
                        Text = level.Factors[i].Name,
                        Anchor = AnchorStyles.Left
                    };
                    contentTable.Controls.Add(factorLab,1,count);
                }
                //设置第三列
                Button displayButton = new Button()
                {
                    Text = "显示信息",
                    Anchor = AnchorStyles.Left
                };
                contentTable.Controls.Add(displayButton, 2, count);
                count++;
            }

        }

        /// <summary>
        /// 初始化模型，插入目标层
        /// </summary>
        private void InitModel()
        {
            //创建第一层
            Factor factor = new Factor("Z");
            Level toplevel = new Level(null, new List<Factor>() { factor }, null, null);
            //设置初始化的模型
            ahpModel = new AhpModel(toplevel);
        }

        private void levelAdd_Click(object sender, EventArgs e)
        {
            LevelAddForm levelAddForm = new LevelAddForm(ahpModel);
            levelAddForm.ShowDialog();
        }
    }
}
