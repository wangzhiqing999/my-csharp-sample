using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0720_MultiTime.Sample
{

    /// <summary>
    /// 多次数据处理.
    /// 
    /// 
    /// 本类用于解决下面这种业务处理逻辑.
    /// 
    /// 有一个源数据列表， 里面有很多行数据。
    /// 要做一种业务处理， 要求当 某类数据， 存在 指定行数 以上的情况下， 才加入结果列表.
    /// 
    /// 
    /// 举例来说
    ///   例如有一个店铺， 要为本月购物3次（含）以上的 VIP 顾客， 增加 VIP 积分.
    /// 
    /// </summary>
    public class MultiTimeDataProcess<T> where T : IMultiTimeProcessAble
    {

        /// <summary>
        /// 数据有效的次数.
        /// </summary>
        private int accessAbleCount = 2;


        /// <summary>
        /// 数据有效的次数.
        /// 
        /// 也就是 经过多少次处理以后， 才认为此数据是有效的.
        /// </summary>
        public int AccessAbleCount
        {
            set
            {
                accessAbleCount = value;
            }
            get
            {
                return accessAbleCount;
            }
        }



        /// <summary>
        /// 不允许 所有的处理， 都在一天内.
        /// 
        /// 
        /// 此属性用于设置， 
        /// 为了避免 有人利用优惠条件， 本来要购买 5件商品的。
        /// 
        /// 发现有 本月购物3次（含）以上的活动， 就自己手动拆单， 5件商品， 分3个单子购买。
        /// 
        /// </summary>
        public bool NotAllowAllInOneDay { set; get; }



        /// <summary>
        /// 是否需要自动重至.
        /// 
        /// 因为存在 新增 与 删除 两种操作.
        /// 
        /// 
        /// 如果 是 消除性的处理， 那么需要重置。
        /// 
        /// 例如： “最少2次”
        /// 第一行数据是 购买（此时结果列表为空白）
        /// 第二行数据是 购买（此时结果列表为2行数据）
        /// 第三行数据是 退货（此时结果列表为空白）
        /// 第四行数据是 购买（此时结果列表为2行数据）
        /// 
        /// 因为第三次处理， 属于 消除性的处理， 使得行数 不满足 “最少2次”了， 那么以前加入的数据， 都要清理掉。
        /// 
        /// 
        /// 
        /// 
        /// 如果 是 检查重复数据的处理， 那么不需要重置。
        /// 例如： “最少2次”
        /// 第一行数据是 购买（此时结果列表为空白）
        /// 第二行数据是 购买（此时结果列表为2行数据）
        /// 第三行数据是 “第一次购买已被处理”（此时结果列表为1行数据）
        /// 第四行数据是 购买（此时结果列表为2行数据）
        /// 
        /// 因为第三次处理， 属于 检查重复数据的处理， 也就是以前曾经计算过了， 是满足条件的。
        /// 本次计算， 将不重复计算了， 而既然曾经满足过 “最少2次”， 那么认为本次其他数据，也是满足 “最少2次”的。
        /// 因此不将数据， 从结果列表中删除掉.
        /// 
        /// </summary>
        public bool IsNeedAutoReset { set; get; }





        /// <summary>
        /// 结果列表.
        /// </summary>
        private List<T> resultList = new List<T>();


        /// <summary>
        /// 结果列表.
        /// </summary>
        public List<T> ResultList
        {
            get
            {
                return resultList;
            }
        }


        /// <summary>
        /// 临时列表.
        /// 
        /// 当新数据输入时， 如果是从来没有加入过的， 那么加入临时列表.
        /// </summary>
        private List<T> tempList = new List<T>();


        /// <summary>
        /// 标记列表.
        /// 
        /// 用于存储 关键字 与 进入的次数
        /// </summary>
        private Dictionary<string, Dictionary<DateTime, int>> flagDictionary = new Dictionary<string, Dictionary<DateTime, int>>();




        /// <summary>
        /// 取得当前有效行数.
        /// </summary>
        /// <returns></returns>
        private int GetCurrentCount(string keyword)
        {
            if (NotAllowAllInOneDay)
            {
                // 不允许多个交易在同一天.
                // 那就就是 简单返回， 存在有交易的天数。
                return flagDictionary[keyword].Count;
            }
            // 允许多个交易在同一天.
            int result = 0;
            foreach (KeyValuePair<DateTime, int> oneData in flagDictionary[keyword])
            {
                // 递增 交易次数.
                result += oneData.Value;
            }
            // 返回结果.
            return result;
        }




        /// <summary>
        /// 新增数据.
        /// </summary>
        /// <param name="data"></param>
        public void AddData(T data)
        {
            // 取得用于 判断多次处理的 关键字.
            string keyword = data.GetKeyWord();

            // 判断是否是 首次进入.
            if (!flagDictionary.ContainsKey(keyword))
            {
                // 如果是 首次加入， 那么设置 标记列表。
                Dictionary<DateTime, int> dateCount = new Dictionary<DateTime, int>();
                // 注明是  指定日期， 进入次数 = 1.
                dateCount.Add(data.GetProcessDate(), 1);
                // 加入列表.
                flagDictionary.Add(keyword, dateCount);

                // 这种情况下， 认为是 “首次加入”
                // 简单加入 临时列表.
                tempList.Add(data);

                // 返回.
                return;
            }


            // 递增进入次数.
            Dictionary<DateTime, int> oldDateCount = flagDictionary[keyword];
            if (oldDateCount.ContainsKey(data.GetProcessDate()))
            {
                // 该日期，以前曾经增加过数据.
                oldDateCount[data.GetProcessDate()] = oldDateCount[data.GetProcessDate()] + 1;
            }
            else
            {
                // 该日期，以前从未增加过数据.
                oldDateCount.Add(data.GetProcessDate(), 1);
            }




            if (GetCurrentCount(keyword) < accessAbleCount)
            {
                // 进入次数小于  “数据有效的次数”
                // 还是要暂时加入到临时列表中.
                tempList.Add(data);
                // 返回.
                return;
            }


            // 如果可以执行到这里， 说明   进入次数大于等于  “数据有效的次数” 了.                       
            // 本行数据，加入结果列表
            resultList.Add(data);

            // 遍历临时数据列表.
            for (int i = tempList.Count - 1; i >= 0; i--)
            {
                // 获取临时列表中的数据.
                T tempData = tempList[i];

                // 数据判断.
                if (tempData.GetKeyWord() == keyword)
                {
                    // 如果临时数据的 关键字， 与本数据相同.
                    // 将其加入到 正式结果列表.
                    resultList.Add(tempData);

                    // 将这个临时数据，从 临时数据列表中删除.
                    tempList.RemoveAt(i);
                }
            }
        }


        /// <summary>
        /// 删除数据.
        /// </summary>
        /// <param name="data"></param>
        public void RemoveData(T data)
        {
            // 数据是否存在的标志.
            bool isDataExists = false;

            // 用于数据删除的ID.
            string removeID = data.GetID();
            // 尝试从结果列表中检索数据.
            T oldData = resultList.FirstOrDefault(p => p.GetID() == removeID);
            // 结果列表中存在.
            if (oldData != null)
            {
                // 从结果列表中删除.
                resultList.Remove(oldData);

                // 有数据被删除了.
                isDataExists = true;
            }

            // 尝试从临时列表中检索数据.
            oldData = tempList.FirstOrDefault(p => p.GetID() == removeID);
            // 临时列表中存在.
            if (oldData != null)
            {
                // 从临时列表中删除.
                tempList.Remove(oldData);

                // 有数据被删除了.
                isDataExists = true;
            }


            if (!isDataExists)
            {
                // 本次删除
                // 传入的参数， 是一个列表中不存在的数据
                // 直接忽略并返回.
                return;
            }


            // 判断是否数据需要重置.
            if (IsNeedAutoReset)
            {
                // 取得用于 判断多次处理的 关键字.
                string keyword = data.GetKeyWord();
                // 递减进入次数.
                flagDictionary[keyword][data.GetProcessDate()] = flagDictionary[keyword][data.GetProcessDate()] - 1;
                if (flagDictionary[keyword][data.GetProcessDate()] == 0)
                {
                    // 指定日期无数据的情况， 删除掉.
                    flagDictionary[keyword].Remove(data.GetProcessDate());
                }

                // 需要重置.
                if (GetCurrentCount(keyword) < accessAbleCount)
                {
                    // 如果 进入次数小于  “数据有效的次数”
                    // 检查一下，是否有数据，要从结果列表中，移动到临时列表中.
                    if (resultList.Count(p => p.GetKeyWord() == keyword) > 0)
                    {
                        // 有数据需要移动.

                        // 遍历结果数据列表.
                        for (int i = resultList.Count - 1; i >= 0; i--)
                        {
                            // 获取结果列表中的数据.
                            T resultData = resultList[i];

                            // 数据判断.
                            if (resultData.GetKeyWord() == keyword)
                            {
                                // 如果结果数据的 关键字， 与本数据相同.
                                // 将其加入到 临时结果列表.
                                tempList.Add(resultData);

                                // 将这个结果数据，从 结果数据列表中删除.
                                resultList.RemoveAt(i);
                            }
                        }
                    }

                }
            }
        }


    }



}
