using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpertChoose.AHP.Core
{
    public delegate void FactorChangedEventHandler(object sender, FactorChangedEventArgs args);

    interface IFactorChanged
    {
        event FactorChangedEventHandler FactorChaged;
    }

    public class FactorChangedEventArgs : EventArgs
    {

        #region 修改类型枚举

        public enum ChangeType
        {
            Add,
            Remove
        }

        #endregion

        private readonly string _propertyName;

        public FactorChangedEventArgs(string propertyName, ChangeType factorChangeType, Factor changedFactor)
        {
            this._propertyName = propertyName;
            _factorChangeType = factorChangeType;
            _changedFactor = changedFactor;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        private ChangeType _factorChangeType;
        private Factor _changedFactor;

        public Factor ChangedFactor
        {
            get { return _changedFactor; }
        }

        public ChangeType FactorChangeType
        {
            get { return _factorChangeType; }
        }
    }
}
