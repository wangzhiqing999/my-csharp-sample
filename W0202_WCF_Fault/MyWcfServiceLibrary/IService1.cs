using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWcfServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        

        [FaultContract(typeof(SystemFault))]
        [FaultContract(typeof(DatabaseFault))]
        [OperationContract]
        CompositeType TestFaults(CompositeType composite);

    }



    // 使用下面示例中说明的数据协定将复合类型添加到服务操作
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }



    #region 使用FaultContract特性为操作指定指定SOAP Faults




    /// <summary>
    /// 系统异常.
    /// </summary>
    [DataContract]
    public class SystemFault
    {
        [DataMember]
        public string SystemOperation { get; set; }

        [DataMember]
        public string SystemReason { get; set; }

        [DataMember]
        public string SystemMessage { get; set; }
    }


    /// <summary>
    /// 数据库异常.
    /// </summary>
    [DataContract]
    public class DatabaseFault
    {
        [DataMember]
        public string DbOperation { get; set; }

        [DataMember]
        public string DbReason { get; set; }

        [DataMember]
        public string DbMessage { get; set; }
    }


    #endregion


}
