using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHP.Core
{
    //todo:考虑增加特定的异常类型，例如矩阵维数不匹配等
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
