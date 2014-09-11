using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA.Core.Utils
{
    public class Pair<T1, T2>
    {
        public Pair(T1 v1, T2 v2)
        {
            Value1 = v1;
            Value2 = v2;
        }

        public Pair()
        {
        }

        public T1 Value1 { get; set; }
        public T2 Value2 { get; set; }
    }
}
