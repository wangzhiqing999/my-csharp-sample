using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

using MEF_0001_Service.Sample;


namespace MEF_0001_ServiceImpl.Sample
{

    /// <summary>
    /// 插件类.
    /// 
    /// 该项目， 不直接被  客户端 项目 引用.
    /// 
    /// 客户端 项目 只引用  接口定义的 项目。
    /// 
    /// 在编译的时候， 客户端不知道 运行的时候， 会使用哪一个接口实现服务类。
    /// 
    /// 
    /// 
    /// 插件类需要使用Export标记，并且声称导出类型。 
    /// 
    /// </summary>
    [Export(typeof(IDemoInterface))]
    public class DemoService : IDemoInterface
    {


        public void Send(string msg)
        {
            Console.WriteLine("MEF_0001_ServiceImpl.Sample.Send( {0} )", msg);
        }
    }


}
