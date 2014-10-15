using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExpertChooseSystem.Helper;
using ExpertChooseSystem.Model;

namespace ExpertChooseSystem
{
    public partial class MainWindow : Form
    {
        private IList<Project> _projects;
        private IList<Expert> _experts;
        private IList<double> _wights;

        public MainWindow()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            _projects = new ProjectHelper().GetProjects(400);
            _experts = new ExpertHelper().GetExperts(110);
            dataGridView1.DataSource = _projects;
            dataGridView2.DataSource = _experts;

            _wights = new List<double>();
            for (int i = 0; i < 14; i++)
                _wights.Add(0);
        }

        //点击设置属性的权重
        private void button1_Click(object sender, EventArgs e)
        {
            WightInputWindow wightInputWindow = new WightInputWindow(_wights);
            wightInputWindow.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要匹配的专家");
                return;
            }
            String selectedProjectName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Project selectedProject = _projects.First(x => x.Name.Equals(selectedProjectName));
            IList<Expert> candidates = _experts.Where(x => x.Field.Equals(selectedProject.Field) && !x.Name.Equals(selectedProject.MasterName)).ToList();

            MatchWindow matchWindow = new MatchWindow(selectedProject, candidates, _wights);
            matchWindow.ShowDialog();
        }
    }
}
