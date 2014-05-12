using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHP.Core
{
    public abstract class Identified
    {
        //id使用累加数，同时为了保障不会重复，只能通过GetId函数获得
        private static int _idcounter = 0;

        protected static int GetId()
        {
            return ++_idcounter;
        }

        private int _id;
        /// <summary>
        /// 本层次的ID
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        protected Identified()
        {
            _id = GetId();
        }

    }
}
