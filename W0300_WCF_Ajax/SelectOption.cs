using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace W0300_WCF_Ajax
{

    /// <summary>
    /// HTML 的  Select 下的  Option 信息.
    /// </summary>
    [DataContract]
    public class SelectOption
    {

        public SelectOption()
        {
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="optionValue"></param>
        /// <param name="optionText"></param>
        public SelectOption(string optionValue, string optionText)
        {
            // 设置 选择数据的值.
            this.OptionValue = optionValue;

            // 设置 显示的文本.
            this.OptionText = optionText;
        }



        /// <summary>
        /// 用于表示选择数据的值.
        /// </summary>
        [DataMember]
        public string OptionValue
        {
            set;
            get;
        }


        /// <summary>
        /// 用于显示的文本
        /// </summary>
        [DataMember]
        public string OptionText
        {
            set;
            get;
        }


    }


}