using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChooseSystem.Model
{
    class Project
    {
        public String Field { get; set; }
        public String Name { get; set; }
        public List<Expert> ReviewExperts { get; set; }
    }
}
