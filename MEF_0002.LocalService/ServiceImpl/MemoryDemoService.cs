using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.Composition;

using MEF_0002.Service;


namespace MEF_0002.ServiceImpl
{

    /// <summary>
    /// 本地内存服务实现.
    /// 
    /// 本项目， 需要引用 System.ComponentModel.Composition
    /// 
    /// CreationPolicy.Shared 意味着 共享部件，既Shared类型的插件部件可以在多个MEF组合容器中共用
    /// </summary>
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export("MemoryDemoService", typeof(IDemoService))]
    public class MemoryDemoService : IDemoService
    {

        public MemoryDemoService()
        {
            Console.WriteLine("#MemoryDemoService 构造函数执行(CreationPolicy.Shared)......");
        }




        public void SaveData(string text)
        {
            Console.WriteLine("使用本地服务， 将数据 {0} 保存在本地内存区域当中...", text);
        }
    }
}
