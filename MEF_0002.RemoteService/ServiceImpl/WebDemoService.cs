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
    /// 远程Web服务实现.
    /// 
    /// 本项目， 需要引用 System.ComponentModel.Composition
    /// 
    /// </summary>
    [Export("WebDemoService", typeof(IDemoService))]
    public class WebDemoService : IDemoService
    {
        public void SaveData(string text)
        {
            Console.WriteLine("使用远程服务， 将数据 {0} 保存在远程网站上...", text);
        }
    }
}
