using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0711_Merge.Sample
{

    ///	<summary>
    ///	该类用于模拟一个需要 合并 处理的数据对象.
    ///	</summary>
    public class TestData : MergeAble
    {
        ///	<summary>
        ///	数据库内部自增编号.
        ///	</summary>
        public int? Id { set; get; }

        /// <summary>
        /// 用户数据代码.
        /// </summary>
        public string Code { set; get; }

        ///	<summary>
        ///	数值.
        ///	</summary>
        public string Val { set; get; }

        /// <summary>
        /// 有效性标志，True为有效， False为逻辑删除.
        /// </summary>
        public bool? Availability { set; get; }


        public override string ToString()
        {
            return String.Format(
                "测试数据[ID={0}; Code={1}; VAL={2}; Availability={3}]", 
                Id, Code, Val, Availability);
        }

        /// <summary>
        /// 关联方式.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool On(MergeAble other)
        {
            // 首先数据转换.
            TestData otherTestData = other as TestData;
            // 对于 TestData 类，以 Code 为基准进行关联.
            return this.Code == otherTestData.Code;
        }

        /// <summary>
        /// 匹配 更新
        /// </summary>
        /// <param name="newData"></param>
        /// <returns></returns>
        public MergeAble GetWhenMatchedResult(MergeAble newData)
        {
            // 首先克隆 旧数据.
            TestData result = this.MemberwiseClone() as TestData;
            // 数据转换.
            TestData newTestData = newData as TestData;
            // 仅仅 更新 Val
            result.Val = newTestData.Val;
            // 返回.
            return result;
        }

        /// <summary>
        /// 不匹配 插入.
        /// </summary>
        /// <returns></returns>
        public MergeAble GetWhenNotMatchedResult()
        {
            // 克隆 新数据.
            TestData result = this.MemberwiseClone() as TestData;
            // ID 由服务器生成.这里仅仅设置 可用性标志.
            result.Availability = true;
            // 简单返回.
            return result;
        }

        /// <summary>
        /// 不匹配 删除.
        /// </summary>
        /// <returns></returns>
        public MergeAble GetWhenNotMatchedBySourceResult()
        {
            // 克隆 旧数据.
            TestData result = this.MemberwiseClone() as TestData;
            // 设置删除标志位.
            result.Availability = false;
            // 返回.
            return result;
        }
    }

}
