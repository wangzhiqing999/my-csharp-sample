using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0001_Sudoku.Model
{

    /// <summary>
    /// 动态的 项目单元格.
    /// 
    /// 在数独计算中， 本类用于存储一个 单元格上的 初始化的是空白的数值信息.
    /// 计算的目的，就是计算出结果， 填写到本类当中.
    /// </summary>
    public class DynamicsItem : AbstractItem
    {


        public DynamicsItem()
        {
            // 初始化 运行时可用数据列表
            RuntimeUsableValueList = new List<int>();
        }


        /// <summary>
        /// 默认可用数据列表.（初始状态下）
        /// </summary>
        public List<int> DefaultUsableValueList { private set; get; }



        /// <summary>
        /// 初始化 默认列表.
        /// </summary>
        /// <param name="maxValue"> 计算中的最大数值. </param>
        public void InitDefaultList(int maxValue)
        {
            if (DefaultUsableValueList == null)
            {
                DefaultUsableValueList = Enumerable.Range(1, maxValue).ToList();
            }
        }





        #region 运行时属性.



        /// <summary>
        /// 运行时可用数据列表.
        /// </summary>
        public List<int> RuntimeUsableValueList { set; get; }


        /// <summary>
        /// 运行时 临时数据.
        /// </summary>
        public int RuntimeTempValue { set; get; }


        /// <summary>
        /// 运行时 临时锁定.
        /// </summary>
        public bool RuntimeTempLock { set; get; }



        /// <summary>
        /// 重置运行时数据.
        /// </summary>
        public void ResetRuntimeData()
        {
            // 重置运行时可用列表.
            RuntimeUsableValueList.Clear();
            RuntimeUsableValueList.AddRange(DefaultUsableValueList);

            RuntimeTempValue = 0;
            RuntimeTempLock = false;
        }



        /// <summary>
        /// 尝试设置 运行时 数据.
        /// </summary>
        /// <param name="tmpVal"></param>
        public void TrySetValue(int tmpVal)
        {
            this.RuntimeTempValue = tmpVal;
            this.RuntimeTempLock = true;
        }


        /// <summary>
        /// 尝试删除 运行时可用数据.
        /// </summary>
        /// <param name="tmpVal"></param>
        public void TryRemoveUsable(int tmpVal)
        {
            RuntimeUsableValueList.Remove(tmpVal);
        }



        #endregion 运行时属性.






        /// <summary>
        /// 返回默认可用的数据字符.
        /// </summary>
        /// <returns></returns>
        public string GetDefaultUsableValu()
        {
            return String.Join(";", DefaultUsableValueList);
        }


        /// <summary>
        /// 返回运行时可用的数据字符.
        /// </summary>
        /// <returns></returns>
        public string GetRuntimeUsableValu()
        {
            return String.Join(";", RuntimeUsableValueList);
        }


        /// <summary>
        /// 动态结果
        /// </summary>
        /// <returns></returns>
        public override int ResultValue()
        {
            return RuntimeTempValue;
        }





        public override string ToString()
        {
            return String.Format("项目坐标({0}, {1}) 初始情况可用={2}  当前可用={3}   当前值={4}",
                this.X, this.Y, this.GetDefaultUsableValu(), this.GetRuntimeUsableValu(), RuntimeTempValue);
        }
    }
}
