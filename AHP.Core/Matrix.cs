﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHP.Core
{
    #region 输入输出委托定义

    public delegate void MatrixInputer(Matrix matrix);
    public delegate void MatrixOutputer(Matrix matrix);

    #endregion

    public class Matrix
    {
        #region 静态成员

        //置矩阵的最大维数为50*50
        public static int MaxX = 50;
        public static int MaxY = 50;

        #endregion

        #region 字段和属性

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


        //定义一个二维列表，用来存储实际的数据，所有的操作都是围绕这
        private List<List<double>> innerData;

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数，设置矩阵矩阵的维数，矩阵的维数设置之后，就不可以再修改了
        /// </summary>
        /// <param name="x">矩阵的行数</param>
        /// <param name="y">矩阵的列数</param>
        public Matrix(int x, int y)
        {
            this.x = x;
            this.y = y;

            innerData = new List<List<double>>();
            Init();
        }

        /// <summary>
        /// 构造函数，设置矩阵矩阵的维数，矩阵的维数设置之后，就不可以再修改了
        /// </summary>
        /// <param name="x">矩阵的行数</param>
        /// <param name="y">矩阵的列数</param>
        /// <param name="name">矩阵的名字</param>
        public Matrix(int x, int y, string name)
            : this(x, y)
        {
            Name = name;
        }

        #endregion

        #region 矩阵的基本操作，包括初始化、设置单个值、插入矩阵、输出矩阵

        /// <summary>
        /// 初始化，将矩阵全都值为0
        /// </summary>
        public void Init()
        {
            for (int i = 0; i < x; i++)
            {
                List<double> temp = new List<double>();
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
        public double this[int x, int y]
        {
            get { return innerData[x][y]; }
            set { innerData[x][y] = value; }
        }

        /// <summary>
        /// 输入数组数据
        /// </summary>
        /// <param name="inputer">数组输入接口的委托</param>
        public void InsertMatrix(MatrixInputer inputer)
        {
            inputer(this);
        }

        /// <summary>
        /// 显示数组
        /// </summary>
        public void DisplayMatrix(MatrixOutputer outputer)
        {
            outputer(this);
        }

        #endregion

        #region 矩阵运算，包括相加、点乘、矩阵相加、获得最大值、求和、子集、计算特征值、转置

        /// <summary>
        /// 导入数据源
        /// </summary>
        /// <param name="source"></param>
        public void InsertDataFromList(IList<double> source)
        {
            if (source.Count >= X * Y)
            {
                int count = 0;
                for (int i = 0; i < X; i++)
                {
                    for (int j = 0; j < Y; j++)
                    {
                        innerData[i][j] = source[count];
                        count++;
                    }
                }
            }
            else
            {
                throw new MatrixCalExcetpion("数据源的没有足够数量的数据用来构建矩阵");
            }
        }

        /// <summary>
        /// 矩阵相加
        /// </summary>
        /// <param name="other">另一个相加的矩阵</param>
        /// <param name="resultName">结果矩阵的名字，可为空</param>
        /// <returns>相加后的结果</returns>
        public Matrix Add(Matrix other, string resultName = null)
        {
            //结果矩阵的name
            string name = resultName ?? string.Format("{0} + {1}", Name, other.Name);
            Matrix result = new Matrix(X, Y, name);

            if (X == other.X && Y == other.Y)
            {
                for (int i = 0; i < X; i++)
                {
                    for (int j = 0; j < Y; j++)
                    {
                        result[i, j] = this[i, j] + other[i, j];
                    }
                }
            }
            else
            {
                throw new MatrixCalExcetpion("两个相加的矩阵必须有相同的维数");
            }
            return result;
        }

        /// <summary>
        /// 矩阵点乘
        /// </summary>
        /// <param name="multiplier">相乘的数</param>
        /// <param name="resultName">结果矩阵的名称</param>
        /// <returns>点乘后的结果</returns>
        public Matrix DotMultiply(double multiplier, string resultName = null)
        {
            //结果矩阵的name
            string name = resultName ?? string.Format("{0} * {1}", Name, multiplier);
            Matrix result = new Matrix(X, Y, name);

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    result[i, j] = this[i, j] * multiplier;
                }
            }

            return result;
        }

        /// <summary>
        /// 向量的左乘
        /// </summary>
        /// <param name="rightMatrix">另一个相乘的矩阵</param>
        /// <param name="resultName">结果矩阵的名称</param>
        /// <returns>向量左乘的结果</returns>
        public Matrix LeftMultipy(Matrix rightMatrix, string resultName = null)
        {
            //结果矩阵的name
            string name = resultName ?? string.Format("{0} * {1}", Name, rightMatrix.Name);
            Matrix result = new Matrix(X, rightMatrix.Y, name);

            if (Y == rightMatrix.X)
            {
                for (int i = 0; i < X; i++)
                {
                    for (int j = 0; j < rightMatrix.Y; j++)
                    {
                        double temp = 0;
                        for (int k = 0; k < Y; k++)
                        {
                            temp += innerData[i][k] * rightMatrix[k, j];
                        }
                        result[i, j] = temp;
                    }
                }
            }
            else
            {
                throw new MatrixCalExcetpion("相乘两个矩阵中，左边矩阵的列数必须与右边矩阵的行数相等");
            }
            return result;
        }

        /// <summary>
        /// 获取指定区域内的最大值
        /// </summary>
        /// <param name="mx">返回最大值的x</param>
        /// <param name="my">返回最大值的y</param>
        /// <param name="xStart">区域起始点x</param>
        /// <param name="xEnd">区域结束点x</param>
        /// <param name="yStart">区域起始点y</param>
        /// <param name="yEnd">区域结束点y</param>
        /// <returns>指定区域中的最大值</returns>
        public double GetMaxValue(out int mx, out int my, int xStart, int yStart, int xEnd, int yEnd)
        {
            if (!RegionCheck(xStart, yStart, xEnd, yEnd))
            {
                throw new MatrixCalExcetpion("请输入一个有效区域");
            }
            mx = xStart;
            my = yStart;
            double max = innerData[xStart][yStart];
            for (int i = xStart; i <= xEnd; i++)
            {
                for (int j = yStart; j <= yEnd; j++)
                {
                    if (innerData[i][j] > max)
                    {
                        mx = i;
                        my = j;
                        max = innerData[i][j];
                    }
                }
            }
            return max;
        }

        /// <summary>
        /// 获取整个矩阵中的最大值，并返回最大值的坐标
        /// </summary>
        /// <param name="mx">最大值的行</param>
        /// <param name="my">最大值的列</param>
        /// <returns>最大值</returns>
        public double GetMaxValue(out int mx, out int my)
        {
            return GetMaxValue(out mx, out my, 0, 0, X - 1, Y - 1);
        }

        /// <summary>
        /// 获取整个矩阵中的最大值
        /// </summary>
        /// <returns>最大值</returns>
        public double GetMaxValue()
        {
            int tempx;
            int tempy;
            return GetMaxValue(out tempx, out tempy, 0, 0, X - 1, Y - 1);
        }

        /// <summary>
        /// 获取指定区域内元素的和
        /// </summary>
        /// <param name="xStart">区域起始点x</param>
        /// <param name="xEnd">区域结束点x</param>
        /// <param name="yStart">区域起始点y</param>
        /// <param name="yEnd">区域结束点y</param>
        /// <returns>指定区域中元素的和</returns>
        public double GetSum(int xStart, int yStart, int xEnd, int yEnd)
        {
            if (!RegionCheck(xStart, yStart, xEnd, yEnd))
            {
                throw new MatrixCalExcetpion("请输入一个有效区域");
            }
            double sum = 0;
            for (int i = xStart; i <= xEnd; i++)
            {
                for (int j = yStart; j <= yEnd; j++)
                {
                    sum += innerData[i][j];
                }
            }
            return sum;
        }

        /// <summary>
        /// 获得所有元素之和
        /// </summary>
        /// <returns>所有元素之和</returns>
        public double GetSum()
        {
            return GetSum(0, 0, X - 1, Y - 1);
        }

        /// <summary>
        /// 获取指定区域内的子矩阵
        /// </summary>
        /// <param name="xStart">区域起始点x</param>
        /// <param name="xEnd">区域结束点x</param>
        /// <param name="yStart">区域起始点y</param>
        /// <param name="yEnd">区域结束点y</param>
        /// <param name="resultName">结果矩阵的名字</param>
        /// <returns>指定区域中元素的子矩阵</returns>
        public Matrix GetSubMatrix(int xStart, int yStart, int xEnd, int yEnd, string resultName = null)
        {
            if (!RegionCheck(xStart, yStart, xEnd, yEnd))
            {
                throw new MatrixCalExcetpion("请输入一个有效区域");
            }
            //设置结果矩阵的名字
            string name = resultName ?? string.Format("{0}的子矩阵 ({1},{2})->({3},{4})", Name, xStart, yStart, xEnd, yEnd);
            //子矩阵的行和列
            int subx = xEnd - xStart + 1;
            int suby = yEnd - yStart + 1;

            Matrix result = new Matrix(subx, suby, name);
            IList<double> tempList = new List<double>();
            for (int i = xStart; i <= xEnd; i++)
            {
                for (int j = yStart; j <= yEnd; j++)
                {
                    tempList.Add(innerData[i][j]);
                }
            }
            result.InsertDataFromList(tempList);
            return result;
        }

        /// <summary>
        /// 计算矩阵的最大特征值和特征向量
        /// </summary>
        /// <param name="eigenVector">输出矩阵的特征向量</param>
        /// <returns>矩阵的最大特征值</returns>
        public double Power(out Matrix eigenVector)
        {
            //            Matrix xk = GetSubMatrix(0,0,0,X);
            //            double c = 0;
            //            Matrix yk = new Matrix(xk.X, xk.Y); Matrix yk = Matrix();
            //            //迭代次数
            //            int count = 50;
            //            Matrix old_xk = xk;
            //
            //            while (count > 0)
            //            {
            //                yk = LeftMultipy(xk);
            //                c = xk.GetMaxValue();
            //                xk = yk.dotProduct(1 / c);
            //
            //                //以下代码有问题，当差很小，计算出来的epsilon总是很大
            //                double epsilon = 0.0;
            //                for (int i = 0; i < xx; i++)
            //                {
            //                    double cha = xk.getValue(i, 0) - old_xk.getValue(i, 0);
            //                    epsilon = epsilon + pow(cha, 2);
            //                }
            //                old_xk = xk;
            //                if (sqrt(epsilon) < EPSILON)
            //                {
            //                    break;
            //                }
            //                count--;
            //            }
            //
            //            eigenValue = c;
            //            eigenVector = &xk;

            eigenVector = null;
            return 0;
        }

        /// <summary>
        /// 获得矩阵的归一化矩阵
        /// </summary>
        /// <returns>归一化的矩阵</returns>
        public Matrix GetNormalized(string resultName = null)
        {
            //设置结果矩阵的名字
            string name = resultName ?? string.Format("{0}的归一化矩阵)", Name);
            Matrix result = new Matrix(X, Y, name);
            for (int i = 0; i < X; i++)
            {
                double columnSum = GetSum(0, i, X - 1, i);
                for (int j = 0; j < Y; j++)
                {
                    result[i, j] = this[i, j] / columnSum;
                }
            }
            return result;
        }

        /// <summary>
        /// 矩阵转置
        /// </summary>
        /// <returns>转置后的矩阵</returns>
        public Matrix GetTranspose(string resultName = null)
        {
            //设置结果矩阵的名字
            string name = resultName ?? string.Format("{0}的转置矩阵)", Name);
            Matrix result = new Matrix(Y, X, name);
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    result[i, j] = this[j, i];
                }
            }
            return result;

        }

        /// <summary>
        /// 检查区域是否为有效区域
        /// </summary>
        /// <param name="xStart">区域上边界</param>
        /// <param name="xEnd">区域下边界</param>
        /// <param name="yStart">区域左边界</param>
        /// <param name="yEnd">区域右边界</param>
        /// <returns>该区域是否有效</returns>
        private bool RegionCheck(int xStart, int yStart, int xEnd, int yEnd)
        {
            if (xStart <= xEnd
               && yStart <= yEnd
               && xStart >= 0
               && yStart >= 0
               && xEnd < X
               && yEnd < Y)
                return true;
            return false;
        }

        #endregion
    }
}
