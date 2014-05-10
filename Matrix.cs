using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChooseCore
{
    public class Matrix
    {
        //置矩阵的最大维数为50*50
        public static int MaxX = 50;
        public static int MaxY = 50;

        #region 定义矩阵的行(X)和列(Y)
        private readonly int x;
        private readonly int y;

        /// <summary>
        /// 获得矩阵的行
        /// </summary>
        public int X
        {
            get { return x; }
        }

        /// <summary>
        /// 获得矩阵的列
        /// </summary>
        public int Y
        {
            get { return y; }
        }
        #endregion

        //定义一个二维列表，用来存储实际的数据，所有的操作都是围绕这
        private List<List<double>> innerData;

        /// <summary>
        /// 构造函数，用设置矩阵矩阵的维数，矩阵的维数设置之后，就不可以再修改了
        /// </summary>
        /// <param name="x">矩阵的行数</param>
        /// <param name="y">矩阵的列数</param>
        public Matrix(int x, int y)
        {
            this.x = x;
            this.y = y;

            innerData=new List<List<double>>();
            Init();
        }

        /// <summary>
        /// 初始化，将矩阵全都值为0
        /// </summary>
        public void Init()
        {
            for (int i = 0; i < x; i++)
            {
                List<double> temp=new List<double>();
                for (int j = 0; j < y; j++)
                {
                    temp.Add(0);
                }
                innerData.Add(temp);
            }
        }

        /// <summary>
        /// 类型索引，用来获取和设置矩阵中某个位置的值
        /// </summary>
        /// <param name="x">矩阵行</param>
        /// <param name="y">矩阵列</param>
        /// <returns></returns>
        public double this[int x, int y] {
            get { return innerData[x][y]; }
            set { innerData[x][y] = value; }
        }

        /// <summary>
        /// 输入数组数据
        /// </summary>
        /// <param name="inputer">数组输入接口的实现</param>
        public void InsertMatrix(IMatrixInputer inputer)
        {
            inputer.InsertData(this);
        }

        /// <summary>
        /// 显示数组
        /// </summary>
        public void DisplayMatrix()
        {

        }
    }
}
