using System;

namespace GA.Core.Interface
{
    public interface IFuzzySubjectionCalculator
    {
        double CalSubject(String projectSubject, String expertSubject);
        double CalCompany(String projectCompany, String expertCompany);
    }
}
