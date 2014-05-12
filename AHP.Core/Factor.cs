using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHP.Core
{
    public class Factor
    {
        public Factor(int id, string name, FactorDirection direction)
        {
            Id = id;
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
