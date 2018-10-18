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
    /// 本地文件服务实现.
    /// 
    /// 本项目， 需要引用 System.ComponentModel.Composition
    /// </summary>
    [PartCreationPolicy(CreationPolicy.Any)]
    [Export("FileDemoService", typeof(IDemoService))]
    public class FileDemoService : IDemoService
    {


        public FileDemoService()
        {
            Console.WriteLine("#FileDemoService 构造函数执行......");
        }


        public void SaveData(string text)
        {
            Console.WriteLine("使用本地服务， 将数据 {0} 保存在本地文件当中...", text);
        }
    }
}
