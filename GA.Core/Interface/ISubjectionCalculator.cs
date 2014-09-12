using System;

namespace GA.Core.Interface
{
    public interface ISubjectionCalculator<T1, T2>
    {
        double Calculate(T1 value1, T2 value2);
    }
}
