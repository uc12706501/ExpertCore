using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Core.Interface;

namespace GA.Core
{
    public class SubjectionTable
    {
        private List<List<double>> subjectionTable;
        private IList<Expert> experts;

        //构造函数
        public SubjectionTable(Project project, IList<Expert> experts, IFuzzySubjectionCalculator c)
        {
            this.experts = experts;

            //新建一个空的二维数组来存放隶属度表
            subjectionTable = new List<List<double>>(2);
            for (int i = 0; i < 2; i++)
            {
                List<double> subjectionsOfProperty = new List<double>(ItemCount);
                subjectionTable.Add(subjectionsOfProperty);
            }

            //计算和填充隶属度
            for (int i = 0; i < ItemCount; i++)
            {
                subjectionTable[i][0] = c.CalCompany(project.Company, experts[i].Company);
                subjectionTable[i][1] = c.CalCompany(project.Subject, experts[i].Subject);
            }
        }

        #region 获取隶属度表中的某一列

        public List<double> GetSubjectionsOfCompany()
        {
            return GetSubjectionOfProperty(0);
        }

        private List<double> GetSubjectionsOfSubject()
        {
            return GetSubjectionOfProperty(1);
        }

        private List<double> GetSubjectionOfProperty(int col)
        {
            List<double> subjections = new List<double>(ItemCount);
            for (int i = 0; i < ItemCount; i++)
                subjections.Add(subjectionTable[i][col]);
            return subjections;
        }

        #endregion

        #region 获取隶属度表中的某一行

        public List<double> GetSubjectionOfItem(int row)
        {
            return new List<double>(2) { subjectionTable[row][0], subjectionTable[row][1] };
        }

        #endregion

        #region 获取某个专家的隶属度

        public List<double> GetSubjectionOfExpert(Expert expert)
        {
            int index = experts.IndexOf(expert);
            return new List<double>(2) { subjectionTable[index][0], subjectionTable[index][1] };
        }

        #endregion

        #region 获取隶属度表

        public List<List<double>> GetSubectionTable()
        {
            return subjectionTable;
        }

        #endregion

        public int ItemCount
        {
            get
            {
                return experts.Count;
            }
        }

        public double this[int i, int j]
        {
            get { return subjectionTable[i][j]; }
        }
    }
}
