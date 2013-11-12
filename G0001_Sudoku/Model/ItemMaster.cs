using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using log4net;



namespace G0001_Sudoku.Model
{


    /// <summary>
    /// 数据管理类.
    /// 
    /// 
    /// 在数独计算中, 本类用于存储整个 棋盘中的所有数据.  
    /// 
    /// 
    /// 包含： 
    /// 单元格的初始的固定值。
    /// 单元格的需要动态填写的对象。
    /// 分组数据列表 （行、列、宫）
    /// 
    /// </summary>
    public class ItemMaster
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        /// <summary>
        /// 构造函数.
        /// </summary>
        public ItemMaster()
        {
            // 固定的单元列表.
            FixItemList = new List<FixedItem>();

            // 动态的单元列表.
            DynamicsItemList = new List<DynamicsItem>();

            // 数据组
            ItemGroupList = new List<ItemGroup>();
        }




        #region 基本属性.


        /// <summary>
        /// 固定的单元列表.
        /// </summary>
        public List<FixedItem> FixItemList { set; get; }



        /// <summary>
        /// 动态的单元列表.
        /// </summary>
        public List<DynamicsItem> DynamicsItemList { set; get; }



        /// <summary>
        /// 数据组.
        /// </summary>
        public List<ItemGroup> ItemGroupList { set; get; }




        /// <summary>
        /// 操作列表.
        /// </summary>
        public List<OneProcess> todoList = new List<OneProcess>();





        /// <summary>
        /// 返回明细数据.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public AbstractItem this[int i, int j]
        {
            get
            {
                // 如果检索到固定值，那么返回固定值.
                FixedItem fixItem = FixItemList.FirstOrDefault(p => p.X == i && p.Y == j);
                if (fixItem != null)
                {
                    return fixItem;
                }

                // 否则返回动态值.
                return this.DynamicsItemList.First(p => p.X == i && p.Y == j);


            }
        }


        #endregion 基本属性.





        #region 有效性检查.



        /// <summary>
        /// 是否处理成功.
        /// </summary>
        /// <returns></returns>
        public bool IsAllProcessSuccess
        {
            get
            {
                foreach (ItemGroup itemGroup in ItemGroupList)
                {
                    if (!itemGroup.IsProcessSuccess)
                    {
                        // 只要有一个组未成功，那么认为未成功.
                        return false;
                    }
                }


                if (logger.IsDebugEnabled)
                {
                    logger.Debug("所有的项目都成功了...");
                }

                // 如果能执行到这里.
                // 如果所有的项目都成功了.
                return true;
            }
        }




        /// <summary>
        /// 是否存在有数据处理错误.
        /// </summary>
        /// <returns></returns>
        public bool IsExistsProcessFail
        {
            get
            {
                foreach (ItemGroup itemGroup in ItemGroupList)
                {
                    if (itemGroup.IsProcessFail)
                    {
                        if(logger.IsDebugEnabled) {

                            logger.DebugFormat("{0} 数据检查失败，存在有数据的可用数据为空!", itemGroup.GroupName);

                        }

                        // 只要有一个组失败了，那么认为存在失败.
                        return true;
                    }
                }
                // 如果能执行到这里.
                // 如果所有的项目都没有失败！
                return false;
            }
        }



        #endregion







        #region 方法.


        /// <summary>
        /// 重置数据.
        /// </summary>
        public void ResetAllData()
        {

            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("重置数据！当前操作列表为：{0}", String.Join(";",  todoList.Select(p=>p.ToString())));
            }

            foreach (DynamicsItem oneData in DynamicsItemList)
            {
                oneData.ResetRuntimeData();
            }

            foreach (OneProcess oneProcess in todoList)
            {
                DataChange(oneProcess.x, oneProcess.y, oneProcess.Value);
            }
        }



        /// <summary>
        /// 指定位置数据发生变化
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void DataChange(int xIndex, int yIndex, int value)
        {

            // 首先取得指定位置的数据.
            DynamicsItem data =
                DynamicsItemList.FirstOrDefault(p => p.X == xIndex && p.Y == yIndex);


            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("### 尝试对 {0}  设置一个数值: {1}", data, value);
            }


            // 设置数据.
            data.TrySetValue(value);

            // 然后更新相关组内的关联数据.
            foreach (ItemGroup itemGroup in ItemGroupList)
            {
                itemGroup.DataChange(xIndex, yIndex, value);
            }
        }





        /// <summary>
        /// 新增一行数据处理记录.
        /// </summary>
        /// <param name="process"></param>
        private void AddProcess(OneProcess process)
        {
            todoList.Add(process);
        }







        
        /// <summary>
        /// 开始处理.
        /// </summary>
        public bool DoProcess()
        {

            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat(
                    "DoProcess 处理开始， 目前固定单元格数={0}， 未处理单元格数={1}，已处理单元格数={2}。",
                    this.FixItemList.Count(),
                    this.DynamicsItemList.Count(p => p.RuntimeTempLock == false),
                    this.DynamicsItemList.Count(p => p.RuntimeTempLock == true));
            }


            // 检索 当前所有的 项目
            // 按照 “可用数据” 进行排序.
            var query =
                from data in this.DynamicsItemList
                where
                    data.RuntimeTempLock == false
                orderby
                    data.RuntimeUsableValueList.Count
                select data;

            // 取得第一个满足条件的数据.
            DynamicsItem topData = query.First();



            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("当前选中的项目：  {0}",  topData);
            }



            // 复制 当前数据的， 运行时可用节点.
            List<int> tmpRuntimeList = new List<int>();
            tmpRuntimeList.AddRange(topData.RuntimeUsableValueList);


            // 成功处理标志.
            bool successFlag = false;


            // 遍历尝试每个节点.
            foreach (int tmpVal in tmpRuntimeList)
            {

                if (this.IsAllProcessSuccess)
                {
                    // 全部处理成功， 结束并返回.
                    return true;
                }


                // 尝试设置.
                DataChange(topData.X , topData.Y, tmpVal);


                if (this.IsAllProcessSuccess)
                {
                    // 全部处理成功， 结束并返回.
                    return true;
                }

                if (this.IsExistsProcessFail)
                {
                    // 处理失败， 需要回朔.
                    ResetAllData();
                    continue;
                }

                // 暂时是成功的， 加入处理列表.
                AddProcess(new OneProcess() { x = topData.X, y = topData.Y, Value = tmpVal });

                // 重算下一个层次.
                successFlag = DoProcess();


                if (!successFlag)
                {

                    todoList.RemoveAt(todoList.Count - 1);
                    // 处理失败， 需要回朔.
                    ResetAllData();
                }
            }


            // 假如本单元的所有项目， 都处理失败了， 那么返回 false.
            return successFlag;
        }


        #endregion 方法.




    }

}
