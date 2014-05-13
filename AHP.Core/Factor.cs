using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHP.Core
{
    public class Factor
    {
        public Factor(string name, FactorDirection direction)
        {
            Name = name;
            Direction = direction;
        }

        public Factor(string name)
        {
            Name = name;
            Direction = FactorDirection.Positive;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public FactorDirection Direction { get; set; }
    }

    public enum FactorDirection
    {
        Positive, Negative
    }
}
