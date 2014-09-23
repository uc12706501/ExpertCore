using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChoose.AHP.Core
{
    //ahp需要的数据的一个模型
    public class LevelDataModel
    {
        public IList<Factor> Factors { get; set; }
        public Level Parent { get; set; }
        public Matrix RelationMatrix { get; set; }
        public Dictionary<Factor,JudgeMatrix> JudgeMatrices { get; set; }

        public LevelDataModel()
        {
            Factors = new List<Factor>();
            Parent = null;
            JudgeMatrices = new Dictionary<Factor, JudgeMatrix>();
            RelationMatrix = null;
        }

        //todo:实现对模型数据的检查
        public bool Check()
        {
            return true;
        }
    }
}
