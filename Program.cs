using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AHP.Core;

namespace ExpertChooseCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个3*3的矩阵，并通过List赋值
            Matrix m1 = new Matrix(3, 3, "m1");
            IList<double> listsource = new List<double>() { 3, 2, 1, 4, 5, 6, 7, 8, 9, 11 };
            m1.InsertDataFromList(listsource);
            m1.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //创建一个3*3矩阵，然后通过默认方法赋值
            Matrix m2 = new Matrix(3, 3, "m2");
            m2.InsertMatrix(MatrixHelper.DefaultInput);
            m2.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //m1+m2，然后赋值给m3
            Matrix m3 = m1.Add(m2);
            m3.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //m1*4
            Matrix m4 = m2.DotMultiply(4);
            m4.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //m5与m6相乘
            Matrix m5 = new Matrix(2, 2, "m5");
            m5.InsertDataFromList(new List<double>() { 1, 1, -1, -1 });
            m5.DisplayMatrix(MatrixHelper.ConsoloOutput);
            Matrix m6 = new Matrix(2, 2, "m6");
            m6.InsertDataFromList(new List<double>() { -1, 2, 3, 0 });
            m6.DisplayMatrix(MatrixHelper.ConsoloOutput);
            Matrix m7 = m5.LeftMultipy(m6);
            m7.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //找出m8中最大的值
            Matrix m8 = new Matrix(4, 4, "m8");
            m8.InsertDataFromList(new List<double>() { 1, 2, 4, 7, 6, 7, 8, 7, 9, 8, 7, 15, 4, 5, 8, 8, 9, 45, 5 });
            m8.DisplayMatrix(MatrixHelper.ConsoloOutput);
            int x8, y8;
            double m8max = m8.GetMaxValue(out x8, out y8);
            Console.WriteLine(string.Format("最大值坐标是第{0}行第{1}列，为{2}\n", x8 + 1, y8 + 1, m8max));

            //求m8中所有元素之和
            double sumRow1 = m8.GetSum(0, 0, 0, 3);
            Console.WriteLine(string.Format("矩阵m8中第一行值之和为{0}", sumRow1));
            double sumColumn1 = m8.GetSum(0, 0, 3, 0);
            Console.WriteLine(string.Format("矩阵m8中第一列值之和为{0}", sumColumn1));
            double sum = m8.GetSum();
            Console.WriteLine("矩阵m8中所有值之和{0}\n", sum);

            //求m8中元素的最大绝对值
            int abma, abmb;
            double maxAbs = m8.GetMaxAbsoluteValue(out abma, out abmb);
            Console.WriteLine("m8的最大绝对值为第{1}行第{2}列的{0}\n", maxAbs, abma, abmb);

            //获得m8的一个子矩阵(0,0)->(2,1)
            Matrix m9 = m8.GetSubMatrix(0, 0, 2, 1);
            m9.DisplayMatrix(MatrixHelper.ConsoloOutput);
            m9 = m8.GetSubMatrix(0, 2, 3, 2);
            m9.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //获得m8的归一化矩阵
            Matrix m10 = m8.GetNormalized();
            m10.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //获取m11的转置矩阵
            Matrix m11 = new Matrix(4, 2, "m11");
            m11.InsertDataFromList(new List<double>() { 1, 2, 4, 7, 6, 7, 8, 7, 9, 8, 7, 15, 4, 5, 8, 8, 9, 45, 5 });
            m11.DisplayMatrix(MatrixHelper.ConsoloOutput);
            Matrix m12 = m11.GetTranspose();
            m12.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //获取m13的转置矩阵
            Matrix m13 = new Matrix(3, 3, "m13");
            m13.InsertDataFromList(new List<double>() { 1, -3, 3, 3, -5, 3, 6, -5, 4 });
            //m13.InsertMatrix(MatrixHelper.ConsoloInput);
            m13.DisplayMatrix(MatrixHelper.ConsoloOutput);
            double eiginvalue;
            Matrix m14 = m13.Power(out eiginvalue);
            Console.WriteLine(string.Format("矩阵m14对应的最大特征值为{0}", eiginvalue));
            m14.DisplayMatrix(MatrixHelper.ConsoloOutput);

            Console.ReadKey();
        }
    }
}
