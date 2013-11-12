using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

using MyWcfService;


namespace MyWcfClientByHand
{

    /// <summary>
    /// 调用 WCF 服务的客户端.
    /// </summary>
    class MyWcfServiceClient : ClientBase<IMyWcfService>, IMyWcfService
    {

        public MyWcfServiceClient()
            : base()
        { }

        public MyWcfServiceClient(string endpointConfigurationName)
            : base(endpointConfigurationName)
        { }

        public MyWcfServiceClient(Binding binding, EndpointAddress address)
            : base(binding, address)
        { }



        #region  实现 WCF 接口的代码.


        /// <summary>
        /// 客户端调用方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetData(int value)
        {
            return this.Channel.GetData(value);
        }


        /// <summary>
        /// 客户端调用方法
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            return this.Channel.GetDataUsingDataContract(composite);
        }

        #endregion


    }


}
