using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChoose.AHP.Core
{
    public class DataHelper
    {
        /// <summary>
        /// 从控制台输入矩阵
        /// </summary>
        /// <param name="matrix">需要填充的矩阵</param>
        public static void ConsoloInput(Matrix matrix)
        {
            Console.WriteLine("请输入一个{0}行{1}列的矩阵", matrix.X, matrix.Y);
            for (int i = 0; i < matrix.X; i++)
            {
                Console.WriteLine(string.Format("请输入数组第{0}行的{1}个数据，以空格分隔", i + 1, matrix.Y));
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
        /// 从控制台一次输入矩阵的所有数据
        /// </summary>
        /// <param name="matrix">要输入数据的矩阵</param>
        public static void ConsoleArrayInput(Matrix matrix)
        {
            int n = matrix.X * matrix.Y;
            var doubleValues = ReadValus<double>(string.Format("请输入{0}个数据", n), n);
            matrix.InsertDataFromList(doubleValues);
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

        /// <summary>
        /// 在控制台输出矩阵
        /// </summary>
        /// <param name="matrix">要输出的矩阵</param>
        public static void ConsoloOutput(Matrix matrix)
        {
            string matrixName = matrix.Name ?? "#未命名矩阵";
            Console.WriteLine("{0}#{1}", matrixName, matrix.Id);
            for (int i = 0; i < matrix.Y; i++)
            {
                Console.Write(new string('-', 16));
            }
            Console.WriteLine();

            for (int i = 0; i < matrix.X; i++)
            {
                Console.Write("|");
                for (int j = 0; j < matrix.Y; j++)
                {
                    Console.Write(string.Format("{0,8:F3}\t", matrix[i, j]));
                }
                Console.WriteLine("|");
            }

            for (int i = 0; i < matrix.Y; i++)
            {
                Console.Write(new string('-', 16));
            }
            Console.WriteLine();
        }

        //从键盘读入Y/N
        public static bool ReadBool(string message)
        {
            while (true)
            {
                Console.WriteLine(message + "[y/n]");
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    var readkey = readLine.ToLower();
                    if (readkey == "y")
                    {
                        return true;
                    }
                    if (readkey == "n")
                    {
                        return false;
                    }
                }
                Console.WriteLine("请输入Y或者N");
            }
        }

        //从键盘读入一个不为空的值
        public static IList<string> ReadStrings(string message)
        {
            string readkey;
            while (true)
            {
                Console.WriteLine(message);
                readkey = Console.ReadLine();
                if (readkey != null)
                    break;
            }
            return readkey.Split(' ');
        }

        //从键盘读入一个不为空的值
        public static IList<T> ReadValus<T>(string message)
        {
            //用来存放结果的变量
            List<T> result = new List<T>();

            while (true)
            {
                //将读入的一行分解为数组
                string readLine;
                while (true)
                {
                    Console.WriteLine(message);
                    readLine = Console.ReadLine();
                    if (!string.IsNullOrEmpty(readLine))
                        break;
                    Console.WriteLine("请输入非空的字符！");
                }
                var stringArray = readLine.Split(' ');

                //如果出现转换错误，就将result设置为null
                try
                {
                    foreach (var s in stringArray)
                    {
                        T sValue;
                        sValue = (T)Convert.ChangeType(s, typeof(T));
                        result.Add(sValue);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("输入的值无法转换成对应的类型，请重新输入！");
                    result.Clear();
                }

                if (result.Count != 0)
                    break;
            }
            return result;
        }

        /// <summary>
        /// 从键盘读入n个T类型的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IList<T> ReadValus<T>(string message, int n)
        {
            //用来存放结果的变量
            List<T> result = new List<T>();

            while (true)
            {
                //将读入的一行分解为数组
                string readLine;
                while (true)
                {
                    Console.WriteLine(message);
                    readLine = Console.ReadLine();
                    if (readLine != null)
                        break;
                }
                var stringArray = readLine.Split(' ');

                //如果出现转换错误，就将result设置为null
                try
                {
                    foreach (var s in stringArray)
                    {
                        T sValue;
                        sValue = (T)Convert.ChangeType(s, typeof(T));
                        result.Add(sValue);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("输入的值无法转换成对应的类型，请重新输入！");
                    result.Clear();
                }

                if (result.Count >= n)
                    break;

                Console.WriteLine("输入的数据不够，请重新输入！");
            }
            return result;
        }

    }
}
