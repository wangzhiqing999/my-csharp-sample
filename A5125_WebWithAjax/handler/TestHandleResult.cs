using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;



namespace A5125_WebWithAjax.handler
{

    /// <summary>
    /// 测试数据处理结果.
    /// </summary>
    [DataContract]
    public class TestHandleResult : CommonHandleResult
    {
        
        /// <summary>
        /// 用户代码.
        /// </summary>
        [DataMember]
        public string UserCode { set; get; }


        /// <summary>
        /// 用户姓名.
        /// </summary>
        [DataMember]
        public string UserName { set; get; }



        /// <summary>
        /// 卡片列表.
        /// </summary>
        [DataMember]
        public List<string> CardList { set; get; }

    }
}