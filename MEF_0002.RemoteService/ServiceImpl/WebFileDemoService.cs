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
    [Export("FileDemoService", typeof(IDemoService))]

    public class WebFileDemoService : IDemoService
    {
        public void SaveData(string text)
        {
            Console.WriteLine("使用远程服务， 将数据 {0} 保存在远程网盘文件当中...", text);
        }
    }
}
