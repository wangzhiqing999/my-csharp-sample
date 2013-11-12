using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0711_Merge.Sample
{

    /// <summary>
    /// 可合并接口.
    /// </summary>
    public interface MergeAble
    {
        /// <summary>
        /// 匹配方法.
        /// 假如当前对象与 目标对象匹配，返回true.
        /// 否则返回 false.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool On(MergeAble other);


        /// <summary>
        /// 获取合并匹配时候的结果.
        /// 仅仅针对 旧对象 调用此方法。
        /// </summary>
        /// <param name="newData"></param>
        /// <returns></returns>
        MergeAble GetWhenMatchedResult(MergeAble newData);


        /// <summary>
        /// 获取合并不匹配时候的结果. 
        /// 旧的无数据，新的有数据。
        /// 此条件下，不传达参数，
        /// 仅仅针对 新对象 调用此方法。
        /// </summary>
        /// <returns></returns>
        MergeAble GetWhenNotMatchedResult();


        /// <summary>
        /// 获取合并不匹配时候的结果. 
        /// 旧的有数据，新的无数据。
        /// 此条件下，不传达参数，
        /// 仅仅针对 旧对象 调用此方法。
        /// </summary>
        /// <returns></returns>
        MergeAble GetWhenNotMatchedBySourceResult();
    }



    /// <summary>
    /// 本类用于演示
    /// 如何创建一个支持泛型处理的类.
    /// 请注意这个类定义的时候，后面有一个 &lt;T&gt;
    /// 这意味着这个类初始化的时候，需要指定操作哪一种特定的数据类型。
    /// 
    /// 后面还有一个 where T : MergeAble
    /// 这意味着泛型能够支持的类，必须要实现 MergeAble 接口.
    ///
    ///
    /// 本类的主要为了在C#客户端，实现像下面的这种处理的操作.
    /// 也就是通过分析 客户端的用户数据，与服务器的后台数据.
    ///
    /// 产生一个合并的结果。
    /// 用于最后的处理，判断哪些数据需要插入，哪些需要更新，哪些需要删除.
    ///
    /// -- 源表
    /// CREATE TABLE test_from (id INT, val VARCHAR(20));
    /// -- 目标表
    /// CREATE TABLE test_to (id INT, val VARCHAR(20));
    /// -- 插入源表
    /// INSERT INTO test_from VALUES (1, 'A');
    /// INSERT INTO test_from VALUES (2, 'B');
    ///
    /// -- 合并 源表到目标表
    /// MERGE test_to USING test_from
    /// ON ( test_to.id = test_from.id )    -- 条件是 id 相同
    /// WHEN MATCHED THEN UPDATE SET test_to.val = test_from.val   -- 匹配的时候，更新
    /// WHEN NOT MATCHED THEN INSERT VALUES(test_from.id, test_from.val) -- 源表有，目标表没有，插入
    /// WHEN NOT MATCHED BY SOURCE THEN DELETE; -- 目标表有，源表没有，目标表该数据删除.
    ///
    /// </summary>
    public class Merge<T> where T : MergeAble
    {

        /// <summary>
        /// 数据合并类型.
        /// </summary>
        public enum MergeType
        {
            /// <summary>
            /// 尚未处理.
            /// </summary>
            NotProcess = 0x00,

            /// <summary>
            /// 数据匹配
            /// </summary>
            Matched = 0x01,

            /// <summary>
            /// 数据不匹配:
            /// 旧数据列表中没有，新数据列表中有.
            /// </summary>
            NotMatched = 0x02,

            /// <summary>
            /// 数据不匹配：
            /// 旧数据列表中有，新数据列表中没有.
            /// </summary>
            NotMatchedBySource = 0x04
        }


        /// <summary>
        /// 合并后的结果.
        /// </summary>
        public class MergeResult
        {
            /// <summary>
            /// 合并的类型.
            /// </summary>
            public MergeType MergeType { set; get; }

            /// <summary>
            /// 已有的旧数据.
            /// </summary>
            public T OldData { set; get; }

            /// <summary>
            /// 新的数据.
            /// </summary>
            public T NewData { set; get; }

            /// <summary>
            /// 最后的结果数据.
            /// </summary>
            public T EndResultData { set; get; }


            /// <summary>
            /// 获取合并结果字符信息.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                StringBuilder buff = new StringBuilder("比较结果：");
                switch (MergeType)
                {
                    case Merge<T>.MergeType.Matched:
                        buff.AppendLine("匹配");
                        break;
                    case Merge<T>.MergeType.NotMatched:
                        buff.AppendLine("不匹配[计划新增]");
                        break;
                    case Merge<T>.MergeType.NotMatchedBySource:
                        buff.AppendLine("不匹配[计划删除]");
                        break;
                    default:
                        buff.AppendLine("未知的情况");
                        break;
                }

                buff.AppendFormat("  旧数据:{0} ", this.OldData);
                buff.AppendLine();
                buff.AppendFormat("  新数据:{0} ", this.NewData);
                buff.AppendLine();
                buff.AppendFormat("  最终处理结果:{0} ", this.EndResultData);
                buff.AppendLine();
                return buff.ToString();
            }
        }


        /// <summary>
        /// 合并处理.
        /// </summary>
        /// <param name="OldList">已有的旧数据列表.</param>
        /// <param name="NewList">新的数据列表</param>
        /// <returns></returns>
        public List<MergeResult> DoMerge(ICollection<T> OldList, ICollection<T> NewList)
        {
            // 首先初始化 比较结果列表
            List<MergeResult> mergeDisplayResultList = new List<MergeResult>();

            // 首先处理大家都有的， 可以进行数据匹配的数据.
            var matchedQuery =
                from oldData in OldList
                from newData in NewList
                where oldData.On(newData)
                select this.WhenMatchedThen(oldData, newData);
            // LINQ 查询结果。 存储到结果列表中.
            mergeDisplayResultList.AddRange(matchedQuery.ToList());

            // 暂存已经匹配的 旧数据列表.
            var matchedOldQuery =
                from data in mergeDisplayResultList
                select data.OldData;
            List<T> matchedOldList = matchedOldQuery.ToList();

            // 暂存已经匹配的 新数据列表.
            var matchedNewQuery =
                from data in mergeDisplayResultList
                select data.NewData;
            List<T> matchedNewList = matchedNewQuery.ToList();


            // 然后处理，不匹配的，也就是旧数据列表中没有，新数据列表中有的.
            var notMatchedQuery =
                from newData in NewList
                where !matchedNewList.Contains(newData)
                select this.WhenNotMatchedThen(newData);
            // LINQ 查询结果。 存储到结果列表中.
            mergeDisplayResultList.AddRange(notMatchedQuery.ToList());


            // 然后处理，不匹配的，也就是旧数据列表中有，新数据列表中没有的.
            var notMatchedBySourceQuery =
                from oldData in OldList
                where !matchedOldQuery.Contains(oldData)
                select this.WhenNotMatchedBySourceThen(oldData);
            // LINQ 查询结果。 存储到结果列表中.
            mergeDisplayResultList.AddRange(notMatchedBySourceQuery.ToList());

            // 返回.
            return mergeDisplayResultList;
        }


        /// <summary>
        /// 在合并过程中，当数据匹配的时候，做什么处理。
        /// </summary>
        /// <param name="oldData"></param>
        /// <param name="newData"></param>
        public virtual MergeResult WhenMatchedThen(T oldData, T newData)
        {
            // 此方法内容可由子类扩展实现。
            // 默认 简单返回.
            MergeResult result = new MergeResult() { OldData = oldData, NewData = newData, MergeType = MergeType.Matched };
            // 设置结果.
            result.EndResultData = (T)oldData.GetWhenMatchedResult(newData);
            return result;
        }

        /// <summary>
        /// 在合并过程中，当数据不匹配的时候，做什么处理.
        /// 也就是 在合并过程中，对于 一个 新的数据
        /// 在 已有的旧数据列表 中，没有找到指定的数据时，做什么处理。
        /// </summary>
        /// <param name="newData"></param>
        public virtual MergeResult WhenNotMatchedThen(T newData)
        {
            // 此方法内容可由子类扩展实现。
            // 默认 简单返回.
            MergeResult result = new MergeResult() { NewData = newData, MergeType = MergeType.NotMatched };
            // 设置结果.
            result.EndResultData = (T)newData.GetWhenNotMatchedResult();
            return result;
        }

        /// <summary>
        /// 在合并过程中，当数据不匹配的时候，做什么处理.
        /// 也就是 在合并过程中，对于 一个 已有的旧数据
        /// 在 新的数据列表 中，没有找到指定的数据时，做什么处理。
        /// </summary>
        /// <param name="oldData"></param>
        public virtual MergeResult WhenNotMatchedBySourceThen(T oldData)
        {
            // 此方法内容可由子类扩展实现。
            // 默认 简单返回.
            MergeResult result = new MergeResult() { OldData = oldData, MergeType = MergeType.NotMatchedBySource };
            // 设置结果.
            result.EndResultData = (T)oldData.GetWhenNotMatchedBySourceResult();
            return result;
        }

    }
}
