using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0750_MainSub.Sample
{


    public class DefaultMainSubDataManager : IMainSubDataManager
    {

        /// <summary>
        /// 子数据所允许的最大值.
        /// </summary>
        public decimal MaxSubValue { set; get; }


        /// <summary>
        /// 默认的构造函数.
        /// </summary>
        public DefaultMainSubDataManager()
        {
            // 初始化 子数据 的上限值.
            MaxSubValue = 5000;
        }


        /// <summary>
        /// 新增一条新的数据
        /// 
        /// （新增一行新的主数据， 服务类负责把这行新的主数据， 拆分为多行子数据.）
        /// 
        /// 处理结果， 将存储在 主数据的  SubDataList 属性中.
        /// </summary>
        /// <param name="mainData"></param>
        public void InsertNewMainData(MainData mainData)
        {
            // 参数有效性检查.
            if (mainData == null)
            {
                throw new ArgumentNullException("主数据不能为空！");
            }
            if (mainData.MainInitValue < 0)
            {
                throw new ArgumentException("主数据金额不能为负数！");
            }


            // 首先， 初始化 主数据的 子数据列表.
            mainData.InitSubDataList();

            // 获取初始的 主数据的 金额.
            decimal remainValue = mainData.MainInitValue;

            // 拆分处理.
            while (remainValue > 0)
            {
                // 构造一个子数据.
                SubData subData = new SubData();

                // 子数据的初始值，为 当前余额， 与 单位最大数值 中， 较小对一个.
                subData.SubInitValue = Math.Min(remainValue, this.MaxSubValue);

                // 余额 = 初始值.
                subData.SubBalanceValue = subData.SubInitValue;

                // 加入列表.
                mainData.SubDataList.Add(subData);

                // 余额递减.
                remainValue -= this.MaxSubValue;
            }


        }




        /// <summary>
        /// 更新一行主数据.
        /// 
        /// (处理前，要求主数据的  SubDataList 属性非空且有效)
        /// 
        /// 处理的主要逻辑， 将修改 主数据的  SubDataList 属性中的相关数值.
        /// </summary>
        /// <param name="mainData">主数据</param>
        /// <param name="changeValue">变化值，增加或减少的数量</param>
        public bool UpdateMainData(MainData mainData, decimal changeValue)
        {
            // 参数有效性检查.
            if (mainData == null)
            {
                throw new ArgumentNullException("主数据不能为空！");
            }
            if (mainData.SubDataList == null)
            {
                throw new ArgumentException("主数据未加载子数据列表！");
            }

            // 中间计算金额.
            decimal remainValue = changeValue;

            if (remainValue > 0)
            {
                // 金额大于0，  是给子数据增加数值.
                // 从后向前遍历.
                for (int i = mainData.SubDataList.Count - 1; i >= 0; i--)
                {
                    // 获取子数据.
                    ISubData subData = mainData.SubDataList[i];

                    // 如果未使用过，那么尝试上一行.
                    if (subData.SubFinishValue == 0)
                    {
                        continue;
                    }

                    // 准备发生变化的数值 =   剩余总金额 与 当前子数据可容纳金额 中，较小的一个.
                    decimal changeVal = Math.Min(remainValue, subData.SubFinishValue);


                    // 剩余金额递减.
                    remainValue -= changeVal;
                    // 子数据余额递增.
                    subData.SubBalanceValue = subData.SubBalanceValue + changeVal;

                    if( remainValue ==0) {
                        break;
                    }
                }
            }
            else
            {
                // 金额小于0，  是给子数据减少数值.

                // 从前向后遍历.
                for (int i = 0; i < mainData.SubDataList.Count; i++)
                {
                    // 获取子数据.
                    ISubData subData = mainData.SubDataList[i];

                    // 准备发生变化的数值 =   需要减少的金额绝对值  与 当前子数据可余额 中，较小的一个.
                    decimal changeVal = Math.Min(Math.Abs(remainValue), subData.SubBalanceValue );

                    // 减少金额变化.
                    remainValue += changeVal;

                    // 子数据余额递减.
                    subData.SubBalanceValue = subData.SubBalanceValue - changeVal;

                    if( remainValue ==0) {
                        break;
                    }
                }
            }


            // 如果变化金额最后为0， 表示处理成功！
            return remainValue == 0;

        }


    }


}
