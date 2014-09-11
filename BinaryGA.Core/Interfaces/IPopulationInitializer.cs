using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryGA.Core
{
    public interface IPopulationInitializer
    {
        Population Initialize();
    }
}
