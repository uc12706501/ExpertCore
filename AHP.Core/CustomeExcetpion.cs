using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHP.Core
{
    public class CustomeExcetpion:Exception
    {
        private string errorMessage;

        public CustomeExcetpion(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
        }
    }
}
