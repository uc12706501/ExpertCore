using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpertChooseCore;

namespace ExpertChooseCore
{
    public class MatrixHelper
    {
        /// <summary>
        /// 从控制台输入矩阵
        /// </summary>
        /// <param name="matrix">需要填充的矩阵</param>
        public static void ConsoloInput(Matrix matrix)
        {
            for (int i = 0; i < matrix.X; i++)
            {
                Console.WriteLine(string.Format("请输入数组第{0}行的{1}个数据，以空格分隔", i + 1));
                //读入控制台的一行数据
                string inputString = Console.ReadLine();
                //如果不为空
                if (inputString != null)
                {
                    //将用户输入的数据以为分隔符，分割为一个数组
                    var doubleStringArray = inputString.Split(' ');
                    for (int j = 0; j < matrix.Y; j++)
                    {
                        //将字符数组中的数据依次转换成double类型，并设置到矩阵相应的位置中
                        double tempIntValue = double.Parse(doubleStringArray[j]);
                        matrix[i, j] = tempIntValue;
                    }
                }
            }

        }

        /// <summary>
        /// 默认填充矩阵
        /// </summary>
        /// <param name="matrix">需要填充的矩阵</param>
        public static void DefaultInput(Matrix matrix)
        {
            for (int i = 0; i < matrix.X; i++)
            {
                for (int j = 0; j < matrix.Y; j++)
                {
                    matrix[i, j] = i + j;
                }
            }

        }
    }

//    public interface IMatrixInputer
//    {
//        void InsertData(Matrix matrix);
//    }
//
//    /// <summary>
//    /// 从控制台输入矩阵
//    /// </summary>
//    public class ConsoloMatrixInputer : IMatrixInputer
//    {
//        public void InsertData(Matrix matrix)
//        {
//            for (int i = 0; i < matrix.X; i++)
//            {
//                Console.WriteLine(string.Format("请输入数组第{0}行的{1}个数据，以空格分隔",i+1));
//                //读入控制台的一行数据
//                string inputString = Console.ReadLine();
//                //如果不为空
//                if (inputString != null)
//                {
//                    //将用户输入的数据以为分隔符，分割为一个数组
//                    var doubleStringArray = inputString.Split(' ');
//                    for (int j = 0; j < matrix.Y; j++)
//                    {
//                        //将字符数组中的数据依次转换成double类型，并设置到矩阵相应的位置中
//                        double tempIntValue = double.Parse(doubleStringArray[j]);
//                        matrix[i, j] = tempIntValue;
//                    }
//                }
//            }
//        }
//    }
//
//    /// <summary>
//    /// 插入默认的测试数据
//    /// </summary>
//    public class DefaultMatrixInputer : IMatrixInputer
//    {
//        public void InsertData(Matrix matrix)
//        {
//            for (int i = 0; i < matrix.X; i++)
//            {
//                for (int j = 0; j < matrix.Y; j++)
//                {
//                    matrix[i, j] = i + j;
//                }
//            }
//        }
//    }

}
