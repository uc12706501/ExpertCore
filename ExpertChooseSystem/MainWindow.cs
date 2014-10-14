using System;
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
        private IList<Project> Projects;
        private IList<Expert> Experts;

        public MainWindow()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            Projects = new ProjectHelper().GetProjects(10);
            Experts = new ExpertHelper().GetExperts(5);
            dataGridView1.DataSource = Projects;
            dataGridView2.DataSource = Experts;
        }
    }
}
