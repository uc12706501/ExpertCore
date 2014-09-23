using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChoose.AHP.Core
{
    /// <summary>
    /// 加入了CI、RI、权重向量等判断矩阵的特性
    /// </summary>
    public class JudgeMatrix : Matrix
    {
        #region 静态成员

        public static Dictionary<int, double> RiTable = new Dictionary<int, double>
            {
                { 1, 0 }, 
                { 2, 0 }, 
                { 3, 0.52 },
                { 4, 0.89 },
                { 5, 1.12 },
                { 6, 1.26 }, 
                { 7, 1.36 },
                { 8, 1.41 },
                { 9, 1.46 },
                { 10, 1.49 },
                { 11, 1.52 },
                { 13, 1.56 },
                { 14, 1.58 },
                { 15, 1.59 }
            };

        #endregion

        #region 继承来的构造函数

        /// <summary>
        /// 判断矩阵的构造函数
        /// </summary>
        /// <param name="d">判断矩阵的维数</param>
        public JudgeMatrix(int d)
            : base(d, d)
        {

        }

        /// <summary>
        /// 判断矩阵的构造函数
        /// </summary>
        /// <param name="d">判断矩阵的维数</param>
        /// <param name="name">判断矩阵的名字</param>
        public JudgeMatrix(int d, string name)
            : base(d, d, name)
        {
        }

        #endregion

        #region 判断矩阵特性方法

        /// <summary>
        /// 计算判断矩阵的CI
        /// </summary>
        /// <returns>判断矩阵的CI</returns>
        public double CI
        {
            get
            {
                double eiginvalue;
                Power(out eiginvalue);
                return (eiginvalue - X) / (X - 1);
            }
        }

        /// <summary>
        /// 获得判断矩阵的RI
        /// </summary>
        /// <returns>判断矩阵的RI</returns>
        public double RI
        {
            get { return RiTable[X]; }
        }

        /// <summary>
        /// 获得判断矩阵的CR
        /// </summary>
        /// <returns>判断矩阵的CR</returns>
        public double CR
        {
            get
            {
                return CI / RI;
            }
        }

        /// <summary>
        /// 获得层次单排序的权重向量
        /// </summary>
        /// <returns>通过判断矩阵获得单因素权重向量</returns>
        public Matrix SingleFactorWightVect(out double eiginValue)
        {
            //获得最大特征值对应的特征向量
            var eiginVector = Power(out eiginValue);
            //获取特征向量的所有元素之和
            var eiginVectSum = eiginVector.GetSum();
            //将所有元素都除以元素之和
            return eiginVector.DotMultiply(1 / eiginVectSum, eiginVector.Name);
        }

        /// <summary>
        /// 获得层次单排序的权重向量
        /// </summary>
        /// <returns>通过判断矩阵获得单因素权重向量</returns>
        public Matrix SingleFactorWightVect()
        {
            double temp;
            return SingleFactorWightVect(out temp);
        }

        /// <summary>
        /// 检查判断矩阵是否符合运算要求
        /// </summary>
        /// <param name="matrix">需要检查的判断矩阵</param>
        /// <returns>true表示符合运算要求</returns>
        public void CheckJudgeMatrix()
        {
            //在求CR、CI、等之前，必须检查是否符合判断矩阵的要求
            //如果判断矩阵包含0，说明构造不完整，不能执行其他运算
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if (Math.Abs(this[i, j] - 0.0) < Epsilon)
                        throw new JudgeMatrixInvalidException("判断矩阵不能有0值！", i, j);
                    if (Math.Abs((int) (this[i, j] * this[j, i] - 1)) > Epsilon)
                        throw new JudgeMatrixInvalidException("判断矩阵中a[i][j]=1/a[j][i]！", i, j);
                }
            }
        }


        #endregion

    }
}
