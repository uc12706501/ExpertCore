using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpertChooseSystem.Model;

namespace ExpertChooseSystem.Helper
{
    public class ExpertHelper
    {
        Random random = new Random();

        public IList<Expert> GetExperts(int count)
        {
            IList<Expert> experts = new List<Expert>();
            int expertCount = 0;
            while (expertCount < count)
            {
                experts.Add(NextExpert());
                expertCount++;
            }
            return experts;
        }

        public Expert NextExpert()
        {
            RandomHelper randomHelper = RandomHelper.GetHelper();

            Expert expert = Expert.Create();
            expert.Name = "Expert#" + Expert.Count;
            expert.Field = randomHelper.NextField();

            //生成基本信息
            expert.Age = random.Next(20, 100);
            expert.TitleRank = random.Next(90, 100);
            expert.DegreeRank = randomHelper.NextDegreeRank();

            //生成专业能力指标
            expert.H = random.Next(20);
            expert.ProjectRank = random.Next(60, 100);
            expert.AwardRank = random.Next(60, 100);
            expert.AwardRank = random.Next(60, 100);

            //生成道德修养指标
            expert.AcademicMoralityCount = random.Next(5);
            expert.AttitudeRank = random.Next(60, 100);
            expert.StyleOfWorkRank = random.Next(60, 100);

            //生成评价业绩指标
            expert.ParticipationRate = random.NextDouble();
            expert.DisperseRate = random.NextDouble();
            expert.HitRate = random.NextDouble();
            expert.SuccessRate = random.Next();

            return expert;
        }
    }
}
