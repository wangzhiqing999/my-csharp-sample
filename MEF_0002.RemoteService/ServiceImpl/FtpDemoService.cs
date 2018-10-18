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
    /// 这个类主要用于测试 导出类的方法和属性
    /// 因此， 在类的上面， 没有写 Export
    /// </summary>
    public class FtpDemoService : IDemoService
    {

        public void SaveData(string text)
        {
            Console.WriteLine("使用远程服务， 将数据 {0} 保存在 FTP 服务器上...", text);
        }


        // 导出属性
        [Export("Path", typeof(string))]
        public string ftpPath = "ftp://192.168.1.2/test";





        // 导出方法 (无参数， 有返回值.)
        [Export("GetPath", typeof(Func<string>))]
        public string GetPath()
        {
            return this.ftpPath;
        }


        // 导出方法 (有参数， 有返回值.)
        [Export("GetFile", typeof(Func<int, string>))]
        public string GetFile(int id)
        {
            return String.Format("{0}/{1}.txt", this.ftpPath, id);
        }


        // 导出方法 (无参数， 无返回值.)
        [Export("ShowPath", typeof(Action))]
        public void ShowPath()
        {
            Console.WriteLine(this.ftpPath);
        }


        // 导出方法 (有参数， 无返回值.)
        [Export("ShowFile", typeof(Action<int>))]
        public void ShowFile(int id)
        {
            Console.WriteLine("{0}/{1}.txt", this.ftpPath, id);
        }
    }
}
