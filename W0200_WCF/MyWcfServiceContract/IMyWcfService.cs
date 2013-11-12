using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWcfService
{
    
	// 本项目仅仅包含  业务接口 与 接口参数/返回值的 类定义
	// 该项目被 WCF 服务端  与  WCF 客户端（手动） 引用。
	
	
	
    /// <summary>
    /// WCF 服务的接口定义.
    /// </summary>
    [ServiceContract]
    public interface IMyWcfService
    {

        /// <summary>
        /// 自动生成的服务方法
        /// 
        /// 传入参数的数据类型为 int
        /// 返回的数据类型为 string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        string GetData(int value);



        /// <summary>
        /// 自动生成的服务方法
        /// 
        /// 传入的参数 与  返回值， 都是 自定义的类.
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        
    }


    /// <summary>
    /// 这个类是 WCF 服务中.
    /// 当服务过程传递的参数、或者返回值
    /// 不是原始数据类型，而是自定义的类的情况下
    /// 需要做的定义设置
    /// </summary>
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
