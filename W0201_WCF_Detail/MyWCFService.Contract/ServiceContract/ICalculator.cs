using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using MyWCFService.DataContract;

namespace MyWCFService.ServiceContract
{

    /// <summary>
    /// 作为 WCF 的 ServiceContract 
    /// 这个项目，需要添加 
    /// System.Runtime.Serialization
    /// System.ServiceModel
    /// 的引用
    /// 
    /// 
    /// 请注意接口定义前，必须要加那个  [ServiceContract]
    /// </summary>
    [ServiceContract]
    public interface ICalculator
    {

        /// <summary>
        /// WCF ServiceContract 所包含的 OperationContract
        /// 
        /// 也就是 接口所提供的方法.
        /// 
        /// 
        /// 注意方法定义前面，必须要加那个  [ServiceContract]
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [OperationContract]
        int Add(int x, int y);



        [OperationContract]
        int Sub(int x, int y);



        [OperationContract]
        int Mul(int x, int y);



        [OperationContract]
        DivResult Div(int x, int y);

    }

}
