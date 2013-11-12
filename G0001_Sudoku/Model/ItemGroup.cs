using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0001_Sudoku.Model
{


    /// <summary>
    /// 项目单元组.
    /// 
    /// 
    /// 在数独计算中，本类用于存储一个 小组中的数据。
    /// 这里的一个小组， 分三种情况：
    /// 1、 一行
    /// 2、 一列
    /// 3、 一宫
    /// 
    /// 本类主要的功能， 就是根据 当前本组内已有的 固定值。
    /// 来估算出那些还没有填写数据的  “可用数据”
    /// 
    /// </summary>
    public class ItemGroup
    {


        #region 基本属性.


        /// <summary>
        /// 组名称.
        /// </summary>
        public string GroupName { set; get; }


        /// <summary>
        /// 固定的单元列表.
        /// </summary>
        public List<FixedItem> FixItemList { set; get; }


        /// <summary>
        /// 动态的单元列表.
        /// </summary>
        public List<DynamicsItem> DynamicsItemList { set; get; }



        #endregion 基本属性.






        #region 初始化方法.


        /// <summary>
        /// 初始化 动态数据的  默认可用数据列表.
        /// </summary>
        public void InitDefaultUsableValueList()
        {

            // 查询目前已有的 数据列表.
            List<int> fixValueList = FixItemList.Select(p => p.IintValue).ToList();


            // 遍历 动态的单元列表
            // 把 目前已有的数据， 从 默认可用数据列表 中删除掉.
            foreach (DynamicsItem item in DynamicsItemList)
            {
                foreach (int val in fixValueList)
                {
                    item.DefaultUsableValueList.Remove(val);
                }
            }

        }



        #endregion 初始化方法.







        #region 处理过程中的判断.


        /// <summary>
        /// 是否处理成功.
        /// </summary>
        /// <returns></returns>
        public bool IsProcessSuccess
        {
            get
            {
                // 查询 数据还没有锁定的.
                int notLockCount =
                    DynamicsItemList.Count(p => p.RuntimeTempLock == false);

                // 如果本组内所有数据， 都已经锁定， 说明本组内数据已处理完毕.
                return notLockCount == 0;
            }
        }




        /// <summary>
        /// 是否处理失败了.
        /// </summary>
        public bool IsProcessFail
        {
            get
            {
                // 查询  数据还没有锁定，  但是  可选数据已经没有了.
                int failCount =
                     DynamicsItemList.Count(
                        p => p.RuntimeTempLock == false && p.RuntimeUsableValueList.Count == 0);

                // 返回
                return failCount > 0;
            }
        }



        #endregion 处理过程中的判断用方法.







        #region 数据处理.





        /// <summary>
        /// 指定位置数据发生变化
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void DataChange(int xIndex, int yIndex, int value)
        {
            // 首先取得指定位置的数据.
            DynamicsItem data =
                DynamicsItemList.FirstOrDefault(p => p.X == xIndex && p.Y == yIndex);

            // 如果 数据不在本组里面. 直接返回.
            if (data == null)
            {
                // 返回.
                return;
            }

            // 如果 数据在本组里面. 本组内的数据， 都要删除掉 “可选数据”
            foreach (DynamicsItem oneData in DynamicsItemList)
            {
                oneData.TryRemoveUsable(value);
            }
        }




        #endregion




    }


}
