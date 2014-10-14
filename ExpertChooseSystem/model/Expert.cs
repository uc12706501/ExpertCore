using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChooseSystem.Model
{
    class Expert
    {
        public String Field { get; set; }
        public String Name { get; set; }

        #region 排序属性

        //基本情况
        public int Age { get; set; }
        public double TitleRank { get; set; }
        public double DegreeRank { get; set; }

        //专业能力指标
        public int H { get; set; }
        public double ProjectRank { get; set; }
        public double AwardRank { get; set; }
        public double PatentRank { get; set; }

        //道德修养指标
        public int AcademicMoralityCount { get; set; }
        public int AttitudeRank { get; set; }
        public int StyleOfWorkRank { get; set; }

        //评价业绩指标
        public double ParticipationRate { get; set; }
        public double DisperseRate { get; set; }
        public double HitRate { get; set; }
        public double SuccessRate { get; set; }

        #endregion
    }
}
