using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpertChoose.AHP.Core;

namespace ExpertChoose.AHP.WinformSystem
{
    public class JudgeMatrixPair
    {
        public Factor AffectedFactor { get; set; }

        public IList<Factor> SubFactors { get; set; }

        //代表常规生成的
        public JudgeMatrix NormalGen { get; set; }

        //代表使用改进方法生成的
        public JudgeMatrix ApprovedGen { get; set; }
    }
}
