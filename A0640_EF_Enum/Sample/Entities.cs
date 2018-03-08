using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace A0640_EF_Enum.Sample
{
    /// <summary>
    /// 状态枚举.
    /// </summary>
    public enum StatusEnum
    {

        //                     +-----------------------------------------------+
        //     提交            V                                               |
        //+-----------+       确认        +----------+    24小时后需要再确认   |
        //|   未确认  |  ------+------->  |  已同意  | ------------------------+
        //+-----------+        |          +----------+
        //                     |
        //                     |          +----------+   拒绝后的数据进入关闭状态   +----------+
        //                     +------->  |  已拒绝  | ---------------------------> |  已关闭  |
        //                                +----------+                              +----------+

        /// <summary>
        /// 正在编辑模式.
        /// </summary>
        OnEdit = 0,

        /// <summary>
        /// 已 提交.
        /// </summary>
        AskFinish = 1,

        /// <summary>
        /// 已 同意.
        /// </summary>
        AcceptFinish = 2,

        /// <summary>
        /// 已拒绝.
        /// </summary>
        RefuseFinish = 4,

        /// <summary>
        /// 已 关闭.
        /// </summary>
        CloseFinish = 8
    }

    /// <summary>
    /// 包装 枚举的 “复杂类型”
    /// </summary>
    public class StatusWrapper
    {
        private StatusEnum m_Type;

        public int Value
        {
            get { return (int)m_Type; }
            set { m_Type = (StatusEnum)value; }
        }

        public StatusEnum EnumValue
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        public static implicit operator StatusWrapper(StatusEnum statusType)
        {
            return new StatusWrapper { EnumValue = statusType };
        }

        public static implicit operator StatusEnum(StatusWrapper stockPoolType)
        {
            if (stockPoolType == null)
                return StatusEnum.OnEdit;
            return stockPoolType.EnumValue;
        }
    }


    /// <summary>
    /// 测试数据.
    /// </summary>
    [Table("test_data")]  
    public class TestData
    {
        /// <summary>
        /// 流水号
        /// 数据库自增主键.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestDataID { set; get; }

        /// <summary>
        /// 名称.
        /// </summary>
        public string TestName { set; get; }

        /// <summary>
        /// 状态.
        /// </summary>
        public StatusWrapper StockPoolStatus { set; get; }


        public override string ToString()
        {
            return String.Format("{0} : {1}", TestName, StockPoolStatus.EnumValue);
        }
    }


}
