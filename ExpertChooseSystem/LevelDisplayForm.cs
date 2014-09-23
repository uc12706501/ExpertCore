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
    public partial class LevelDisplayForm : Form
    {
        #region 字段和构造函数

        private Level _level;

        public LevelDisplayForm(Level level)
            : this()
        {
            _level = level;
            Init();
        }

        private LevelDisplayForm()
        {
            InitializeComponent();
        }

        #endregion

        private void Init()
        {
            DataGridView dgv = new DataGridView()
            {
                Width = 700,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
            };
            dgv.DataSource = _level.GetTotalWeightVect().Transpose().ToDataTable();
            //设置显示格式
            dgv.CellFormatting += (sender, e) =>
            {
                //不处理新建行
                if (e.RowIndex != dgv.NewRowIndex)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("N3");
                }
            };

            totalSortPanel.Controls.Add(dgv);

            ciLabel.Text = string.Format("CI={0:f4}", _level.LevelCI);
            riLabel.Text = string.Format("RI={0:f4}", _level.LevelRI);
            crLabel.Text = string.Format("CR={0:f4}", _level.LevelCR);
        }
    }
}
