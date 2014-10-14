using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChooseSystem.Model
{
    public class Project
    {
        private static int _count;
        public static int Count
        {
            get { return _count; }
        }

        private Project()
        {
        }

        public static Project Craete()
        {
            _count++;
            return new Project();
        }

        public String Name { get; set; }
        public String Field { get; set; }
        public List<Expert> ReviewExperts { get; set; }
    }
}
