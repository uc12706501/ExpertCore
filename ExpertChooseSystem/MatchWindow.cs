using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExpertChooseSystem.Model;

namespace ExpertChooseSystem
{
    public partial class MatchWindow : Form
    {
        private Project _project;
        private IList<Expert> _candidates;
        private IList<double> _weights;

        public MatchWindow(Project project, IList<Expert> candidates, IList<double> weights)
        {
            _project = project;
            _candidates = candidates;
            _weights = weights;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            dataGridView1.DataSource = new List<Project>() { _project };
            dataGridView2.DataSource = _candidates;
        }
    }
}
