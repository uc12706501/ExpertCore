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
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
            };
            dgv.DataSource = _level.GetTotalWeightVect().Transpose().ToDataTable();
            totalSortPanel.Controls.Add(dgv);

            ciLabel.Text = string.Format("CI={0:f4}", _level.LevelCI);
            riLabel.Text = string.Format("CI={0:f4}", _level.LevelRI);
            crLabel.Text = string.Format("CI={0:f4}", _level.LevelCR);
        }
    }
}
