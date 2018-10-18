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
    /// 临时文件服务实现.
    /// 
    /// CreationPolicy.NonShared 表示不共享部件实例，每当有新的请求就会创建一个新的对象实例。
    /// 
    /// </summary>
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export("TempDemoService", typeof(IDemoService))]
    public class TempDemoService : IDemoService
    {

        public TempDemoService() 
        {
            // 由于是 不共享的， 因此， 这个构造函数， 将被执行多次.
            Console.WriteLine("#TempDemoService 构造函数执行(CreationPolicy.NonShared)......");
        }


        public void SaveData(string text)
        {
            Console.WriteLine("使用本地服务， 将数据 {0} 保存在本地临时数据区域当中...", text);
        }


        
        // 导出属性
        [Export("Path", typeof(string))]
        public string localTempPath = "/Temp";





        // 导出方法 (无参数， 有返回值.)
        [Export("GetTempPath", typeof(Func<string>))]
        public string GetPath()
        {
            return this.localTempPath;
        }


        // 导出方法 (有参数， 有返回值.)
        [Export("GetTempFile", typeof(Func<int, string>))]
        public string GetFile(int id)
        {
            return String.Format("{0}/{1}.txt", this.localTempPath, id);
        }


        // 导出方法 (无参数， 无返回值.)
        [Export("ShowTempPath", typeof(Action))]
        public void ShowPath()
        {
            Console.WriteLine(this.localTempPath);
        }


        // 导出方法 (有参数， 无返回值.)
        [Export("ShowTempFile", typeof(Action<int>))]
        public void ShowFile(int id)
        {
            Console.WriteLine("{0}/{1}.txt", this.localTempPath, id);
        }



 
    }
}
