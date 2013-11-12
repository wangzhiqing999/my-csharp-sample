using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0740_AutoMatch.Sample
{

    /// <summary>
    /// 抽象共通处理逻辑.
    /// </summary>
    public abstract class AbstractAutoMatchProcesser : IAutoMatchProcesser
    {
        /// <summary>
        /// 可消耗的商品列表
        /// </summary>
        public List<IAutoMatchAble> BaseDataList
        {
            get;
            set;
        }



        /// <summary>
        /// 处理完毕后， 节余点数.
        /// </summary>
        public decimal RemainderValue
        {
            protected set;
            get;
        }




        /// <summary>
        /// 抽象方法， 获取 自动匹配处理结果.
        /// </summary>
        /// <returns></returns>
        public abstract List<AutoMatchResult> GetAutoMatchProcessResult();



        public List<AutoMatchResult> DoAutoMatchProcess(decimal currentValue)
        {

            // 节余点数 初始值=当前剩余点数
            RemainderValue = currentValue;


            // 防错性处理代码 1.
            if (BaseDataList == null || BaseDataList.Count == 0)
            {
                // 如果 礼包为空，那么无论你有多少积分，都无法兑换东西。
                // 因为没东西可以兑换.
                // 返回空白列表.
                return new List<AutoMatchResult>();
            }


            // 将 可消耗的商品列表，按照积分大小，  从高到低排序.
            // 要求的是， 消耗积分数量， 必须大于零.
            // 忽略掉 积分数量小于等于零的错误数据.
            var query =
                from data in BaseDataList
                where data.GetExpendValue() > 0
                orderby data.GetExpendValue() descending
                select data;

            // 商品排序处理.
            BaseDataList = query.ToList();


            // 防错性处理代码 2.
            if (BaseDataList.Count == 1)
            {
                // 预期结果.
                List<AutoMatchResult> resultList = new List<AutoMatchResult>();
                // 如果最后只剩下一个
                // 那就没有任何算法可供选择了
                // 只能选这个商品了。
                IAutoMatchAble oneItem = BaseDataList[0];

                if (RemainderValue >= oneItem.GetExpendValue())
                {
                    // 构造结果对象.
                    AutoMatchResult oneResult = new AutoMatchResult();
                    // 唯一关键字.
                    oneResult.ID = oneItem.GetID();
                    // 数量.
                    oneResult.Count = Convert.ToInt32(Math.Truncate(RemainderValue / oneItem.GetExpendValue()));
                    // 单个结果加入 结果列表.
                    resultList.Add(oneResult);

                    // 剩余可用点数
                    RemainderValue = RemainderValue - oneItem.GetExpendValue() * oneResult.Count;
                }

                // 直接本类处理返回， 不需要其他算法处理了.
                return resultList;
            }


            // 调用具体类方法， 实现相关处理逻辑.
            return GetAutoMatchProcessResult();
        }



    }



}
