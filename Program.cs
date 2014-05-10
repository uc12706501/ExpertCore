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
            Matrix m=new Matrix(3,3);
            
            m.InsertMatrix(MatrixHelper.DefaultInput);
            m.DisplayMatrix(MatrixHelper.ConsoloOutput);

            Console.WriteLine("HelloWorld");
            Console.ReadKey();
        }
    }
}
