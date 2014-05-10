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
            Matrix m1 = new Matrix(3, 3,"m1");
            IList<double> listsource = new List<double>() { 3, 2, 1, 4, 5, 6, 7, 8, 9, 11 };
            m1.InsertDataFromList(listsource);
            m1.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //创建一个3*3矩阵，然后通过默认方法赋值
            Matrix m2 = new Matrix(3, 3,"m2");
            m2.InsertMatrix(MatrixHelper.DefaultInput);
            m2.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //m1+m2，然后赋值给m3
            Matrix m3 = m1.Add(m2);
            m3.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //m1*4
            Matrix m4 = m2.DotMultiply(4);
            m4.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //m5与m6相乘
            Matrix m5=new Matrix(2,2,"m5");
            m5.InsertDataFromList(new List<double>(){1,1,-1,-1});
            m5.DisplayMatrix(MatrixHelper.ConsoloOutput);
            Matrix m6=new Matrix(2,2,"m6");
            m6.InsertDataFromList(new List<double>(){-1,2,3,0});
            m6.DisplayMatrix(MatrixHelper.ConsoloOutput);
            Matrix m7=m5.LeftMultipy(m6);
            m7.DisplayMatrix(MatrixHelper.ConsoloOutput);

            //找出m8中最大的值
            Matrix m8 = new Matrix(4, 4, "m8");
            m8.InsertDataFromList(new List<double>() { 1,2,4,7,6,7,8,7,9,8,7,15,4,5,8,8,9,45,5 });
            m8.DisplayMatrix(MatrixHelper.ConsoloOutput);
            int x8, y8;
            double m8max = m8.GetMaxValue(out x8,out y8);
            Console.WriteLine(string.Format("最大值坐标是第{0}行第{1}列，为{2}",x8+1,y8+1,m8max));

            Console.WriteLine("HelloWorld");
            Console.ReadKey();
        }
    }
}
