using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChoose.BinaryGA.Impl
{
    public class GeneticAlgorithm
    {
        private IFitnessCalculator _fitnessCalculator;
        private ICrossOverOperator _crossOverOperator;
        private ICopyOperator _copyOperator;
        private IMutateOperator _mutateOperator;
        private IStopCondition _stopCondition;
        private IPopulationInitializer _initializer;

        public GeneticAlgorithm(IFitnessCalculator fitnessCalculator, ICrossOverOperator crossOverOperator, ICopyOperator copyOperator, IMutateOperator mutateOperator, IStopCondition stopCondition, IPopulationInitializer initializer)
        {
            _fitnessCalculator = fitnessCalculator;
            _crossOverOperator = crossOverOperator;
            _copyOperator = copyOperator;
            _mutateOperator = mutateOperator;
            _stopCondition = stopCondition;
            _initializer = initializer;
        }

        public BinaryChromosome Calculate()
        {
            Population population = _initializer.Initialize();
            UpdateFitness(population);

            while (!_stopCondition.Check(population))
            {
                population = _copyOperator.Copy(population);
                population = _crossOverOperator.Cross(population);
                population = _mutateOperator.Mutate(population);
                UpdateFitness(population);
            }

            return population.GetBestChromosome();
        }

        private void UpdateFitness(Population population)
        {
            foreach (var chromosome in population)
                chromosome.Fitness = _fitnessCalculator.CalculateFitness(chromosome);
        }
    }
}
