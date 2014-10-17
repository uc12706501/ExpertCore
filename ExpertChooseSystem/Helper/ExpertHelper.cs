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
            expert.PatentRank = random.Next(60, 100);

            //生成道德修养指标
            expert.AcademicMoralityCount = random.Next(5);
            expert.AttitudeRank = random.Next(60, 100);
            expert.StyleOfWorkRank = random.Next(60, 100);

            //生成评价业绩指标
            expert.ParticipationRate = random.NextDouble();
            expert.DisperseRate = random.NextDouble();
            expert.HitRate = random.NextDouble();
            expert.SuccessRate = random.NextDouble();

            return expert;
        }

        public static IList<double> ExpertsToList(IList<Expert> experts)
        {
            var compoundData = new List<double>();
            foreach (var expert in experts)
                compoundData.AddRange(ExpertToList(expert));
            return compoundData;
        }

        public static IList<double> ExpertToList(Expert expert)
        {
            IList<double> data = new List<double>()
            {
                expert.Age,
                expert.TitleRank, 
                expert.DegreeRank, 
                
                expert.H, 
                expert.ProjectRank, 
                expert.AwardRank, 
                expert.PatentRank, 
                
                expert.AcademicMoralityCount, 
                expert.AttitudeRank, 
                expert.StyleOfWorkRank, 
                
                expert.ParticipationRate, 
                expert.DisperseRate, 
                expert.HitRate, 
                expert.SuccessRate
            };

            return data;
        }

        public static IList<string> GetFullPropertyNames()
        {
            return new List<string>()
            {
                "姓名","二级学科","年龄","职称","学历","H指数","项目情况","获奖情况","发明专利","道德累计数","科研态度","工作作风","参与率","离散率","命中率","成功率"
            };
        }

        public static IList<string> GetBriefPropertyNames()
        {
            return new List<string>() { "专家姓名", "评价值" };
        }
    }
}
