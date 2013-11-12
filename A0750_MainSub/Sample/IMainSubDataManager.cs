using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0750_MainSub.Sample
{


    /// <summary>
    /// 主数据 / 子数据管理接口.
    /// </summary>
    public interface IMainSubDataManager
    {



        /// <summary>
        /// 新增一条新的数据
        /// 
        /// （新增一行新的主数据， 服务类负责把这行新的主数据， 拆分为多行子数据.）
        /// 
        /// 处理结果， 将存储在 主数据的  SubDataList 属性中.
        /// </summary>
        /// <param name="mainData"></param>
        void InsertNewMainData(MainData mainData);




        /// <summary>
        /// 更新一行主数据.
        /// 
        /// (处理前，要求主数据的  SubDataList 属性非空且有效)
        /// 
        /// 处理的主要逻辑， 将修改 主数据的  SubDataList 属性中的相关数值.
        /// </summary>
        /// <param name="mainData">主数据</param>
        /// <param name="changeValue">变化值，增加或减少的数量</param>
        bool UpdateMainData(MainData mainData, decimal changeValue);


    }


}
