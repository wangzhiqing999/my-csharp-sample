using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWcfService
{
 
    
    /// <summary>
    /// 这个类是 WCF 服务的实现例子.
    /// 注意：这个类实现了那个  WCF 的服务接口  （ IMyWcfService ）.
    /// 
    /// 
    /// 当光标停留在本窗口，按“启动”按钮后
    /// IIS Express 将启动本Web网站。
    /// 并自动启动一个  WCF 测试客户端。
    /// 让开发者自己选择，要调试哪一个 Web 服务， 以及要传入什么样的参数。并显示WCF执行的结果。
    /// 
    /// 开发者还能查看 WCF 交互过程中，所传递的 XML 信息.
    /// 
    /// </summary>
    public class MyWcfService : IMyWcfService
    {

        /// <summary>
        /// 实现 WCF 服务接口 的代码.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }



        /// <summary>
        /// 实现 WCF 服务接口 的代码.
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
