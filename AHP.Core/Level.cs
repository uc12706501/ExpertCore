using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AHP.Core.Annotations;

namespace AHP.Core
{
    public class Level : Identified, IFactorChanged
    {

        #region 字段和属性

        /// <summary>
        /// 获得本层次因素数量
        /// </summary>
        public int FactorCount
        {
            get { return Factors.Count; }
        }

        /// <summary>
        /// 本层次的上一层次
        /// </summary>
        public Level Parent
        {
            get { return _parent; }
        }

        /// <summary>
        /// 本层次各个元素对于上一层次各个元素的判断矩阵
        /// </summary>
        public Dictionary<Factor, JudgeMatrix> JudgeMatrices
        {
            get { return _judgeMatrices; }
        }

        /// <summary>
        /// 本层次是第几层
        /// </summary>
        public int LevelCount
        {
            get
            {
                if (Parent != null)
                {
                    return Parent.LevelCount + 1;
                }
                return 1;
            }
        }

        /// <summary>
        /// 本层次的各个因素
        /// </summary>
        public IList<Factor> Factors
        {
            get { return _factors; }
        }

        /// <summary>
        /// 获取本层次各个元素与上一层次各个元素之间的关系矩阵
        /// </summary>
        public Matrix RelationMatrix
        {
            get { return _relationMatrix; }
        }

        private Level _parent;
        private Matrix _relationMatrix;
        private Dictionary<Factor, JudgeMatrix> _judgeMatrices;
        private IList<Factor> _factors;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">本层次的上一层次，必须指定，如果是顶层则为null</param>
        public Level(Level parent)
        {
            //todo:关系矩阵的初始化
            _parent = parent;
        }

        #endregion

        #region 层次的主要函数

        /// <summary>
        /// 本层次各个元素与上一层次各个元素的关系矩阵
        /// </summary>
        /// <param name="relationMatrix">关系矩阵</param>
        /// <returns>是否设置成功</returns>
        public void SetRelation(Matrix relationMatrix)
        {
            if (Factors.Count <= 0)
                throw new CustomeExcetpion("还没有设置本层次的元素，请先添加本层次的元素");
            if (Parent == null)
                throw new CustomeExcetpion("本层次为顶层，不需要设置顶层元素");
            if (relationMatrix.X < _relationMatrix.X || relationMatrix.Y < _relationMatrix.Y)
                throw new CustomeExcetpion("传入的关系矩阵的行或者列比需要的少，则无法设置");

            //否则，将关系设置到RelationMatrix
            for (int i = 0; i < _relationMatrix.X; i++)
            {
                for (int j = 0; j < _relationMatrix.Y; j++)
                {
                    if (Math.Abs(relationMatrix[i, j] - 0.0) > 0)
                        _relationMatrix[i, j] = 1;
                }
            }

            //只要关系矩阵修改了，就必须根据关系矩阵，重新生成成对比矩阵序列！！！
            UpdateJudgeMatrices();
        }

        #region  Add/Remove Factor

        /// <summary>
        /// 为本层次添加因素
        /// </summary>
        /// <param name="factor">加入到本层次的因素</param>
        public void AddFactor(Factor factor)
        {
            _factors.Add(factor);

            //添加一个因素之后，修改本层次的关系矩阵
            _relationMatrix.InsertRowAfter(_relationMatrix.X - 1);
            //同时重新生成判断矩阵序列
            UpdateJudgeMatrices();

            //通知下一层更改
            OnFactorChanged("Factors", FactorChangedEventArgs.ChangeType.Add, factor);
        }

        /// <summary>
        /// 为本层次添加因素
        /// </summary>
        /// <param name="factors">加入到本层次的因素</param>
        public void AddFactors(IList<Factor> factors)
        {
            //每添加一个因素，都需要执行一些刷新工作，为了出现不一致的问题，挨个添加并刷新
            foreach (var factor in factors)
            {
                AddFactor(factor);
            }
        }

        /// <summary>
        /// 删除指定序数的因素
        /// </summary>
        /// <param name="id">要删除因素的索引号</param>
        public bool RemoveFactor(int id)
        {
            var factor = Factors.SingleOrDefault(x => x.Id == id);
            if (factor == null)
                return false;

            return RemoveFactor(factor);
        }

        /// <summary>
        /// 删除指定名称的因素
        /// </summary>
        /// <param name="name">要删除因素的名称</param>
        public bool RemoveFactor(string name)
        {
            var factor = Factors.SingleOrDefault(x => x.Name == name);
            if (factor == null)
                return false;

            return RemoveFactor(factor);
        }

        /// <summary>
        /// 根据id
        /// </summary>
        /// <returns></returns>
        public bool RemoveFactorByIndex(int index)
        {
            if (index > Factors.Count) return false;

            var factor = Factors[index];
            return RemoveFactor(factor);
        }

        /// <summary>
        /// 删除指定的Factor
        /// </summary>
        /// <param name="factor">要删除的因素</param>
        /// <returns>是否成功删除</returns>
        public bool RemoveFactor(Factor factor)
        {
            var index = Factors.IndexOf(factor);
            if (index != -1)
                return false;

            //先移除因素
            Factors.Remove(factor);
            //修改关系矩阵
            _relationMatrix.RemoveRow(index);

            //刷新判断矩阵序列
            UpdateJudgeMatrices();
            return true;
        }

        #endregion

        /// <summary>
        /// 设置本层次相对于上一层次中某个因素的的判断矩阵
        /// </summary>
        /// <param name="parentFactor"></param>
        /// <param name="judgeMatrix"></param>
        public void SetJudgeMatrix(Factor parentFactor, JudgeMatrix judgeMatrix)
        {
            //检查parentFactor是否为上一层次总的因素
            if (!Parent.Factors.Contains(parentFactor))
            {
                throw new CustomeExcetpion("上一层不包含指定的因素");
            }
            //检查传入的判断矩阵是否符合要求
            if (!judgeMatrix.CheckJudgeMatrix())
            {
                throw new CustomeExcetpion("传入的判断矩阵不满足判断矩阵的基本要求");
            }
            //设置
            JudgeMatrices.Add(parentFactor, judgeMatrix);
        }

        /// <summary>
        /// 获取本层次各个元素对于上一层次各个元素的排序向量
        /// </summary>
        /// <returns></returns>
        public Matrix GetWeightMatrix()
        {
            //定义权重矩阵的维数
            int wx = FactorCount;
            int wy = Parent.FactorCount;
            Matrix wightMatrix = new Matrix(wx, wy);

            //依次权重矩阵计算每一列的值
            for (int j = 0; j < wy; j++)
            {
                //todo:考虑提取一个公用方法
                //获得当前的列，也就是上层的某个因素
                Factor currentParentFactor = Parent.Factors[j];
                //获得对应该因素的判断矩阵
                var currentJudgeMatrix = JudgeMatrices[currentParentFactor];
                //通过判断矩阵计算层次单排序权重
                var currentWightVect = currentJudgeMatrix.SingleFactorWightVect();
                //设置到权重向量中
                int pointer = 0;
                for (int i = 0; i < wx; i++)
                {
                    //如果关系矩阵的对应位置不为0，就设置该位置的权重
                    if (_relationMatrix[i, j] != 0)
                        wightMatrix[i, j] = currentWightVect[pointer++, 0];
                }
            }
            return wightMatrix;
        }

        /// <summary>
        /// 获取本层次的层次总排序权重向量
        /// </summary>
        /// <returns></returns>
        public Matrix GetTotalWeightVect()
        {
            //如果是第二次，则返回该层次元素的层次单排序权重向量
            if (LevelCount == 2)
                return _judgeMatrices[Parent.Factors[0]].SingleFactorWightVect();

            return GetWeightMatrix().LeftMultipy(Parent.GetTotalWeightVect());
        }

        /// <summary>
        /// 本层次总排序的CI
        /// </summary>
        public double LevelCI
        {
            get
            {
                int parentFactorCount = Parent.Factors.Count;
                IList<double> ciList = new List<double>();
                for (int i = 0; i < parentFactorCount; i++)
                {
                    JudgeMatrix currentJudgeMatrix = JudgeMatrices[Parent.Factors[i]];
                    ciList.Add(currentJudgeMatrix.CI);
                }
                Matrix ciVect = new Matrix(1, parentFactorCount);
                ciVect.InsertDataFromList(ciList);
                Matrix totalci = ciVect.LeftMultipy(GetTotalWeightVect());
                return totalci[0, 0];
            }
        }

        /// <summary>
        /// 本层次总排序的RI
        /// </summary>
        public double LevelRI
        {
            get
            {
                int parentFactorCount = Parent.Factors.Count;
                IList<double> riList = new List<double>();
                for (int i = 0; i < parentFactorCount; i++)
                {
                    JudgeMatrix currentJudgeMatrix = JudgeMatrices[Parent.Factors[i]];
                    riList.Add(currentJudgeMatrix.RI);
                }
                Matrix riVect = new Matrix(1, parentFactorCount);
                riVect.InsertDataFromList(riList);
                Matrix totalRi = riVect.LeftMultipy(GetTotalWeightVect());
                return totalRi[0, 0];
            }
        }

        /// <summary>
        /// 本层次总排序的CR
        /// </summary>
        public double LevelCR
        {
            get
            {
                int parentFactorCount = Parent.Factors.Count;
                IList<double> crList = new List<double>();
                for (int i = 0; i < parentFactorCount; i++)
                {
                    JudgeMatrix currentJudgeMatrix = JudgeMatrices[Parent.Factors[i]];
                    crList.Add(currentJudgeMatrix.CR);
                }
                Matrix crVect = new Matrix(1, parentFactorCount);
                crVect.InsertDataFromList(crList);
                Matrix totalCr = crVect.LeftMultipy(GetTotalWeightVect());
                return totalCr[0, 0];
            }
        }

        #endregion

        #region private成员函数

        /// <summary>
        /// 根据关系矩阵生成空的判断矩阵，每一次关系矩阵修改，都必须调用这个函数
        /// </summary>
        /// <param name="relationMatrix">关系矩阵</param>
        private void UpdateJudgeMatrices()
        {
            //Todo:考虑实现一种不清空关系矩阵的方法
            for (int i = 0; i < _relationMatrix.Y; i++)
            {
                //查找上一层第i个因素影响的本层因素数量
                int affectcount = 0;
                for (int j = 0; j < _relationMatrix.X; j++)
                {
                    affectcount++;
                }
                //如果影响的因素数量不为不为0，则增加一个判断矩阵
                if (affectcount != 0)
                {
                    JudgeMatrix jm = new JudgeMatrix(affectcount);
                    JudgeMatrices.Add(Parent.Factors[i], jm);
                }
            }
        }

        #endregion

        #region 实现IFactorChanged接口，提供属性更改通知

        //当Factor集合更改时，提供通知。本层次重新刷新关系矩阵，通知下一层次刷新
        public event FactorChangedEventHandler FactorChaged;

        protected virtual void OnFactorChanged(string propertyName, FactorChangedEventArgs.ChangeType factorChangeType, Factor changedFactor
            )
        {
            FactorChangedEventHandler handler = FactorChaged;
            if (handler != null) handler(this, new FactorChangedEventArgs(propertyName, factorChangeType, changedFactor));
        }

        #endregion

    }
}
