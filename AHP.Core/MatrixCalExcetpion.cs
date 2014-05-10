using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHP.Core
{
    public class MatrixCalExcetpion:Exception
    {
        private string errorMessage;

        public MatrixCalExcetpion(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
        }
    }
}
