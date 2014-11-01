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
            //Tester.JudgeMatrixTest();
            //Tester.MatrixTest();
            //Tester.AhpModelTest();
            new AhpModelFileTester().Run();
            Console.ReadKey();
        }
    }
}
