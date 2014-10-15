using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AHP.Core;
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

            var ranks = CalculateRanks();
            for (int i = 0; i < _candidates.Count; i++)
            {
                _candidates[i].SetRank(ranks[i]);
            }

            var selectedExpert =
                _candidates.OrderBy(x => x.GetRank()).Select(x => new { Name = x.Name, Rank = x.GetRank() });

            dataGridView3.DataSource = selectedExpert;
        }

        private IList<double> CalculateRanks()
        {
            var weightVect = new Matrix( _weights.Count,1);
            weightVect.InsertDataFromList(_weights);
            DecisionMatrix decisionMatrix = new DecisionMatrix(GetFactors(), _candidates.Count, weightVect);
            return decisionMatrix.GetDecisionVect(Standardizer.ApprovedNormalize).ExportToList();
        }

        private IList<Factor> GetFactors()
        {
            IList<Factor> factors = new List<Factor>()
            {
                new Factor("Age",40),
                new Factor("TitleRank"),
                new Factor("DegreeRank"),

                new Factor("H"),
                new Factor("ProjectRank"),
                new Factor("AwardRank"),
                new Factor("PatentRank"),

                new Factor("AcademicMoralityCount"),
                new Factor("AttitudeRank "),
                new Factor("StyleOfWorkRank"),

                new Factor("ParticipationRate"),
                new Factor("DisperseRate"),
                new Factor("HitRate"),
                new Factor("SuccessRate"),

            };
            return factors;
        }
    }
}
