using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Core.Interface;

namespace GA.Core
{
    public class DefaultFuzzySubjectionCalculator : IFuzzySubjectionCalculator
    {
        public double CalSubject(string projectSubject, string expertSubject)
        {
            throw new NotImplementedException();
        }

        public double CalCompany(string projectCompany, string expertCompany)
        {
            throw new NotImplementedException();
        }
    }
}
