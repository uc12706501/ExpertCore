using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHP.Core
{
    /// <summary>
    /// 矩阵标准化接口，每一种标准化方法都必须实现该接口
    /// </summary>
    public interface IStandardizer
    {
        DecisionMatrix Standardize(DecisionMatrix toBeStandardize);
    }
}
