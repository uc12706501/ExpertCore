﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AHP.Core.Annotations;

namespace AHP.Core
{
    public class Level : Identified
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

        //因为不提供对外修改的接口，所以只能通过构造函数输入所有的数据
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">本层次的上一层次，必须指定，如果是顶层则为null</param>
        private Level(Level parent)
        {
            _parent = parent;
        }

        public Level(Level parent, IList<Factor> factors, Matrix relationMatrix,
                     Dictionary<Factor, JudgeMatrix> judgeMatrices)
        {
            //如果parent为null，说明是顶层元素，只需要设置factors即可
            if (parent == null)
            {
                _factors = factors;
            }
                //否则就需要社会自factors，relationMatrix，judgeMatrices
            else
            {
                //todo:设置之前必须检查是否符合要求啊
                _parent = parent;
                _factors = factors;
                _relationMatrix = relationMatrix;
                _judgeMatrices = judgeMatrices;
            }
        }

        public Level(LevelDataModel dataModel)
        {
            if (!dataModel.Check())
            {
                throw new CustomeExcetpion("数据不符合要求！");
            }
            _parent = dataModel.Parent;
            _factors = dataModel.Factors;
            _relationMatrix = dataModel.RelationMatrix;
            _judgeMatrices = dataModel.JudgeMatrices;
        }

        #endregion

        #region 层次的主要函数

        /// <summary>
        /// 本层次各个元素与上一层次各个元素的关系矩阵
        /// </summary>
        /// <param name="relationMatrix">关系矩阵</param>
        /// <returns>是否设置成功</returns>


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
            //如果是第二层，则返回该层次元素的层次单排序权重向量
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
                if (LevelCount == 2)
                    return _judgeMatrices[Parent.Factors[0]].CI;

                int parentFactorCount = Parent.FactorCount;
                IList<double> ciList = new List<double>();
                for (int i = 0; i < parentFactorCount; i++)
                {
                    JudgeMatrix currentJudgeMatrix = JudgeMatrices[Parent.Factors[i]];
                    ciList.Add(currentJudgeMatrix.CI);
                }
                Matrix ciVect = new Matrix(1, parentFactorCount);
                ciVect.InsertDataFromList(ciList);
                Matrix totalci = ciVect.LeftMultipy(Parent.GetTotalWeightVect());
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
                if (LevelCount == 2)
                    return _judgeMatrices[Parent.Factors[0]].RI;

                int parentFactorCount = Parent.FactorCount;
                IList<double> riList = new List<double>();
                for (int i = 0; i < parentFactorCount; i++)
                {
                    JudgeMatrix currentJudgeMatrix = JudgeMatrices[Parent.Factors[i]];
                    riList.Add(currentJudgeMatrix.RI);
                }
                Matrix riVect = new Matrix(1, parentFactorCount);
                riVect.InsertDataFromList(riList);
                Matrix totalRi = riVect.LeftMultipy(Parent.GetTotalWeightVect());
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
                if (LevelCount == 2)
                    return _judgeMatrices[Parent.Factors[0]].CR;

                int parentFactorCount = Parent.FactorCount;
                IList<double> crList = new List<double>();
                for (int i = 0; i < parentFactorCount; i++)
                {
                    JudgeMatrix currentJudgeMatrix = JudgeMatrices[Parent.Factors[i]];
                    crList.Add(currentJudgeMatrix.CR);
                }
                Matrix crVect = new Matrix(1, parentFactorCount);
                crVect.InsertDataFromList(crList);
                Matrix totalCr = crVect.LeftMultipy(Parent.GetTotalWeightVect());
                return totalCr[0, 0];
            }
        }

        #endregion

        //todo:暂不实现

        #region 暂不实现的功能，主要是对Level状态的修改

        private void SetRelation(Matrix relationMatrix)
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
        private void AddFactor(Factor factor)
        {
            _factors.Add(factor);

            //添加一个因素之后，修改本层次的关系矩阵
            //如果关系矩阵为空，说明还没有初始化过
            if (_relationMatrix == null)
                _relationMatrix = new Matrix(1, Parent.FactorCount);
            else
            {
                //如果不为空，但是没有元素，说明全部都被移除了
                //因为矩阵是不可变的，所以不能通过矩阵的方法来进行插入行，只能通过重新构造一个关系矩阵，并将原来的数据复制进去
                var relationData = _relationMatrix.ExportToList();
                Matrix newRelationMatrix = new Matrix(_relationMatrix.X + 1, _relationMatrix.Y);
                newRelationMatrix.InsertDataFromList(relationData);
            }
            //todo:因为加入的新的元素并没有跟上下层建立关系，所以不需要更新相关属性
            //同时重新生成判断矩阵序列
            //UpdateJudgeMatrices();
            //通知下一层更改
            //OnFactorChanged("Factors", FactorChangedEventArgs.ChangeType.Add, factor);
        }

        /// <summary>
        /// 为本层次添加因素
        /// </summary>
        /// <param name="factors">加入到本层次的因素</param>
        private void AddFactors(IList<Factor> factors)
        {
            //每添加一个因素，都需要执行一些刷新工作，为了出现不一致的问题，依次添加并刷新
            foreach (var factor in factors)
            {
                AddFactor(factor);
            }
        }

        //todo:回调方法，用来处理上一层元素增删的事件

        /// <summary>
        /// 删除指定序数的因素
        /// </summary>
        /// <param name="id">要删除因素的索引号</param>
        private bool RemoveFactor(int id)
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
        private bool RemoveFactor(string name)
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
        private bool RemoveFactorByIndex(int index)
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
        private bool RemoveFactor(Factor factor)
        {
            var index = Factors.IndexOf(factor);
            if (index != -1)
                return false;

            //先移除因素
            Factors.Remove(factor);
            //修改关系矩阵

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
        private void SetJudgeMatrix(Factor parentFactor, JudgeMatrix judgeMatrix)
        {
            //检查parentFactor是否为上一层次总的因素
            if (!Parent.Factors.Contains(parentFactor))
            {
                throw new CustomeExcetpion("上一层不包含指定的因素");
            }
            //检查传入的判断矩阵是否符合要求
            judgeMatrix.CheckJudgeMatrix();
            //设置
            JudgeMatrices.Add(parentFactor, judgeMatrix);
        }

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

        public void CheckJudgeMatrices()
        {
            foreach (var judgeMatrix in JudgeMatrices)
            {
                try
                {
                    if (Parent.JudgeMatrices != null &&
                        (Parent.JudgeMatrices != null || Parent.JudgeMatrices.Count != 0))
                        Parent.CheckJudgeMatrices();

                    judgeMatrix.Value.CheckJudgeMatrix();
                }
                catch (JudgeMatrixInvalidException e)
                {
                    string message = string.Format(
                        "上层因素{0}对应的判断矩阵不满足运算条件，具体信息如下\n{1}\n行={2}\t列={3}", judgeMatrix.Key.Name, e.Message, e.X, e.Y);
                    throw new LevelJudgeMatrixInvaliException(message, e, judgeMatrix.Key);
                }
            }
        }

        /// <summary>
        /// 获取指定上一层元素控制的因素
        /// </summary>
        /// <param name="parentFactor">指定的的上一层因素</param>
        /// <returns>本层次中被控制的因素</returns>
        public IList<Factor> GetAffectFactor(Factor parentFactor)
        {
            IList<Factor> affectFactors=new List<Factor>();
            //表示上一层中的控制因素的索引值
            int parendIndex = Parent.Factors.IndexOf(parentFactor);
            for (int i = 0; i < _relationMatrix.X; i++)
            {
                if (_relationMatrix[i,parendIndex]!=0)
                {
                    affectFactors.Add(Factors[i]);
                }
            }
            return affectFactors;
        }
    }

    //#region 实现IFactorChanged接口，提供属性更改通知

        ////当Factor集合更改时，提供通知。本层次重新刷新关系矩阵，通知下一层次刷新
        //public event FactorChangedEventHandler FactorChaged;

        //protected virtual void OnFactorChanged(string propertyName, FactorChangedEventArgs.ChangeType factorChangeType, Factor changedFactor
        //    )
        //{
        //    FactorChangedEventHandler handler = FactorChaged;
        //    if (handler != null) handler(this, new FactorChangedEventArgs(propertyName, factorChangeType, changedFactor));
        //}

        //#endregion
}
