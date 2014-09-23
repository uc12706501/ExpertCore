using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpertChoose.BinaryGA.Impl;
using ExpertChoose.BinaryGA.Impl.GAImpl;
using ExpertChoose.BinaryGA.Impl.Models;

namespace ExpertChoose.BinaryGA.ConsoleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Project project = new Project();
            IList<Expert> experts = new List<Expert>();
            SubjectionTable subjectionTable = new SubjectionTable(project, experts, new SubjectSubjectionCalculator(), new CompanySubjectionCalculator());
            GeneticAlgorithm ga = new GeneticAlgorithm(new FuzzyFitnessCalculator(subjectionTable, new List<double>() { 0.5, 0.5 }), new TwoPointsCrossOver(), new RouleteeCopy(), new BoundaryMutation(), new FitnessMeetStopCondition(1), new FixmPopulationInitilizer(12, experts.Count, 6));

            Console.Write(ga.Calculate());
        }
    }
}
