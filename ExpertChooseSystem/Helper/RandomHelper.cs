using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExpertChooseSystem.Helper
{
    public class RandomHelper
    {

        private static RandomHelper singleton;
        private Random random;

        public static RandomHelper GetHelper()
        {
            if (singleton == null)
                singleton = new RandomHelper();
            return singleton;
        }

        private Dictionary<int, string> _fieldDictionary;

        private RandomHelper()
        {
            _fieldDictionary = new Dictionary<int, string>();
            _fieldDictionary.Add(0, "40009");
            _fieldDictionary.Add(1, "40010");
            _fieldDictionary.Add(2, "40011");
            _fieldDictionary.Add(3, "40012");
            _fieldDictionary.Add(4, "40013");
            _fieldDictionary.Add(5, "40014");
            _fieldDictionary.Add(6, "40015");

            random = new Random();
        }

        public String NextField()
        {
            int fieldCount = _fieldDictionary.Count;
            int randomKey = random.Next(fieldCount);
            return _fieldDictionary[randomKey];
        }

        public int NextDegreeRank()
        {
            int randomRank = random.Next(3);
            if (randomRank == 0)
                return 60;
            if (randomRank == 1)
                return 70;
            return 90;
        }
    }
}
