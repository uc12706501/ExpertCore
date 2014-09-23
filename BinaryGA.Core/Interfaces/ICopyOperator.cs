using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChoose.BinaryGA.Impl
{
    public interface ICopyOperator
    {
        Population Copy(Population parentGeneration);
    }
}
