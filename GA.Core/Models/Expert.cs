using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChoose.BinaryGA.Impl.Models
{
    public class Expert
    {
        public String Name { get; set; }
        public String Field { get; set; }
        public String Subject { get; set; }
        public String Company { get; set; }

        public override bool Equals(object obj)
        {
            Expert that = (Expert)obj;
            if (that == null)
                return false;
            return this.Name.Equals(that.Name) && this.Field.Equals(that.Field) && this.Subject.Equals(that.Subject) &&
                   this.Company.Equals(that.Company);
        }

        public override int GetHashCode()
        {
            const int hashMultiper = 41;
            int result = 7;
            result = result * hashMultiper + Name.GetHashCode();
            result = result * hashMultiper + Field.GetHashCode();
            result = result * hashMultiper + Subject.GetHashCode();
            result = result * hashMultiper + Company.GetHashCode();
            return result;
        }
    }
}
