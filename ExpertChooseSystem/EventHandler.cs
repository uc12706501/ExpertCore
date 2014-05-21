using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AHP.Core;

namespace ExpertChooseSystem
{
    public delegate void DecisionMatrixSaveHandler(DecisionMatrix decisionMatrix);

    public delegate void JudgeMatrixSaveHandler(JudgeMatrixPair judgeMatrixPair);
}
