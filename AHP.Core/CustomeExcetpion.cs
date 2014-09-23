using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChoose.AHP.Core
{
    //todo:考虑增加特定的异常类型，例如矩阵维数不匹配等
    public class CustomeExcetpion : Exception
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

    public class JudgeMatrixInvalidException : Exception
    {
        private int _x;
        private int _y;
        public int X
        {
            get { return _x; }
        }
        public int Y
        {
            get { return _y; }
        }

        public JudgeMatrixInvalidException(string message, int x, int y)
            : base(message)
        {
            _x = x;
            _y = y;
        }
    }

    public class LevelJudgeMatrixInvaliException : Exception
    {
        private Factor _affectedFactor;
        public Factor AffectedFactor
        {
            get
            {
                return _affectedFactor;
            }
        }

        public LevelJudgeMatrixInvaliException(string message, Exception innerException, Factor affectedFactor) : base(message, innerException)
        {
            _affectedFactor = affectedFactor;
        }
    }
}
