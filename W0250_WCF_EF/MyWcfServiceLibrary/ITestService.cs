using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWcfServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ITestService”。
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);




        /// <summary>
        /// 获取主数据列表.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<test_main> GetTestMain();


        /// <summary>
        /// 获取子数据列表.
        /// </summary>
        /// <param name="testMain"></param>
        /// <returns></returns>
        [OperationContract]
        List<test_sub> GetTestSub(test_main testMain);

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
}
