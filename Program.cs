using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChooseCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m=new Matrix(3,3);
            
            m.InsertMatrix(new ConsoloMatrixInputer());

            Console.WriteLine(m[0,1]);
            Console.WriteLine(m[1,1]);

            Console.WriteLine("HelloWorld");
            Console.ReadKey();
        }
    }
}
