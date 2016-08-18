using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace W0300_WCF_Ajax.AppDemo
{

    /// <summary>
    /// 每周报告的检查结果.
    /// </summary>
    [DataContract]
    public class WeekReportHandleResult : CommonHandleResult
    {
        /// <summary>
        /// 结果列表.
        /// </summary>
        [DataMember]
        public List<OneTimeReport> ResultList { set; get; }

    }



    /// <summary>
    /// 单次的结果.
    /// </summary>
    [DataContract]
    public class OneTimeReport
    {
        /// <summary>
        /// 设备代码.
        /// </summary>
        [DataMember]
        public string EquipmentNo { set; get; }

        /// <summary>
        /// 设备名.
        /// </summary>
        [DataMember]
        public string EquipmentName { set; get; }

        /// <summary>
        /// 记录时间.
        /// </summary>
        [DataMember]
        public String RecordTime { set; get; }
    }

}