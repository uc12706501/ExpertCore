using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHP.Core
{
    public class AhpModel
    {
        private IList<Level> _levels;

        public IList<Level> Levels
        {
            get { return _levels; }
        }

        public AhpModel(Level topLevel)
        {
            _levels = new List<Level>();
            _levels.Add(topLevel);
        }

        /// <summary>
        /// 压入一个新的层次
        /// </summary>
        /// <param name="newLevel">新的层次结构模型</param>
        public void PushLevel(Level newLevel)
        {
            _levels.Add(newLevel);
        }

        /// <summary>
        /// 弹出最底层层次
        /// </summary>
        private void PopLevel()
        {
            _levels.RemoveAt(_levels.Count - 1);
        }

        //获得指定层的信息
        public Level GetLevelInfo(int index)
        {
            return Levels[index - 1];
        }
    }
}
