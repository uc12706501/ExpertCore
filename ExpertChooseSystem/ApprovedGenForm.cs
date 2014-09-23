using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExpertChoose.AHP.Core;

namespace ExpertChoose.AHP.WinformSystem
{
    public partial class ApprovedGenForm : Form
    {
        #region 事件及其处理函数的调用

        public event JudgeMatrixSaveHandler JudgeMatrixSave;

        protected virtual void OnJudgeMatrixSave(JudgeMatrixPair judgematrixpair)
        {
            JudgeMatrixSaveHandler handler = JudgeMatrixSave;
            if (handler != null) handler(judgematrixpair);
        }

        #endregion

        #region 字段和初始化函数

        private JudgeMatrixPair _judgeMatrixPair;
        private DataTable _dataTable;

        //获取被控制因素的数量
        public int FactorCount
        {
            get { return _judgeMatrixPair.SubFactors.Count; }
        }

        public ApprovedGenForm(JudgeMatrixPair judgeMatrixPair)
            : this()
        {
            _judgeMatrixPair = judgeMatrixPair;
            Init();
        }

        private ApprovedGenForm()
        {
            InitializeComponent();
        }

        #endregion

        //执行初始化操作
        private void Init()
        {
            //设置Label的内容，用来显示所有被影响的因素及其本地排序
            int localSort = 0;
            foreach (var subFactor in _judgeMatrixPair.SubFactors)
            {
                string txt = string.Format("{0}：{1}\n", localSort++, subFactor.Name);
                factorsLabel.Text += txt;
            }

            //初始化数据表
            _dataTable = new DataTable();
            for (int i = 0; i < _judgeMatrixPair.ApprovedGen.Y; i++)
            {
                _dataTable.Columns.Add("No." + (i + 1), typeof(int));
            }
            _dataTable.Columns.Add("ρ", typeof(int));
            sortsDataGridView.DataSource = _dataTable;
        }


        //点击保存
        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //检查是否符合要求
                CheckValid();
                //如果检查结果符合要求，就能执行以下步骤
                _judgeMatrixPair.ApprovedGen = CalJudgeMatrix();
                OnJudgeMatrixSave(_judgeMatrixPair);
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        //检查输入顺序的是否满足要求
        private void CheckValid()
        {
            //逐行检查
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                //先获取数据
                //获取当前行的所有数据项
                var items = _dataTable.Rows[i].ItemArray;
                //用来保存排序数据项
                IList<int> tempList = new List<int>();
                for (int j = 0; j < FactorCount; j++)
                {
                    tempList.Add((int)items[j]);
                }
                //获取ρ
                int p = (int)items[FactorCount];

                //排序检查
                for (int j = 0; j < FactorCount; j++)
                {
                    if (!tempList.Contains(j))
                        throw new Exception("请输入正确的排序值！");
                }
                //ρ检查
                if (!(p > 0 && p < 10))
                {
                    throw new Exception("ρ的取值为1-9之间的整数值！");
                }
            }
        }

        //通过表格中的数据计算判断矩阵
        private JudgeMatrix CalJudgeMatrix()
        {
            JudgeMatrix judgeMatrix = new JudgeMatrix(FactorCount);

            //各个专家给出的排序的表
            IList<IList<int>> rateTable = new List<IList<int>>();
            IList<int> pList = new List<int>();
            //表示专家给出的排序个数
            //要排除最后一行空行
            int rateCount = _dataTable.Rows.Count;
            //逐行处理，将数据填充到以上两个List中
            for (int i = 0; i < rateCount; i++)
            {
                //获取当前行的所有数据项
                var items = _dataTable.Rows[i].ItemArray;
                //用来保存排序数据项
                IList<int> tempList = new List<int>();
                for (int j = 0; j < FactorCount; j++)
                {
                    tempList.Add((int)items[j]);
                }
                rateTable.Add(tempList);
                //填充p
                pList.Add((int)items[FactorCount]);
            }

            //计算根据rateTable和pList构造判断矩阵
            double pAvg = pList.Average();
            IList<double> aList = new List<double>();
            //对被影响的因素逐个处理，生成各个被影响因素的平均赋权值
            for (int i = 0; i < FactorCount; i++)
            {
                int sumIndex = 0, avgIndex = 0, pow = 0;
                for (int k = 0; k < rateCount; k++)
                {
                    sumIndex += (rateTable[k].IndexOf(i) + 1);
                }
                avgIndex = sumIndex / rateCount;
                pow = FactorCount - avgIndex + 1;
                aList.Add(pow);
            }
            //对判断矩阵逐个处理插入值
            for (int m = 0; m < FactorCount; ++m)
            {
                for (int n = 0; n < FactorCount; ++n)
                {
                    if (aList[m] >= aList[n])
                    {
                        var numerator = aList[m] - aList[n];
                        var denominator = aList.Max() - aList.Min();
                        judgeMatrix[m, n] = numerator / denominator * (pAvg - 1) + 1;
                    }
                    else
                    {
                        var numerator = aList[n] - aList[m];
                        var denominator = aList.Max() - aList.Min();
                        judgeMatrix[m, n] = 1 / (numerator / denominator * (pAvg - 1) + 1);
                    }
                }
            }
            return judgeMatrix;
        }
    }
}
