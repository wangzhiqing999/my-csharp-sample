using System;
using System.Collections;
using System.Linq;
using System.Text;

using System.Resources;

namespace A0090_Resource.Sample
{
    class ResourceSample
    {

        /// <summary>
        /// 写入 英文 资源文件.
        /// </summary>
        public void WriteEnglishResource()
        {
            // 构造写入器.
            ResourceWriter rw = new ResourceWriter("English.resource");
            rw.AddResource("Hello", "Hello");
            rw.Close();
        }


        /// <summary>
        /// 写入 中文 资源文件.
        /// </summary>
        public void WriteChinaResource()
        {
            // 构造写入器.
            ResourceWriter rw = new ResourceWriter("China.resource");
            rw.AddResource("Hello", "你好");
            rw.Close();
        }



        /// <summary>
        /// 读取 资源文件信息.
        /// </summary>
        /// <param name="resName"></param>
        public void DisplayHello(String resName)
        {
            try
            {
                ResourceReader reader = new ResourceReader(resName + ".resource");
                IDictionaryEnumerator dict = reader.GetEnumerator();
                while (dict.MoveNext())
                {
                    String s = (String)dict.Key;
                    if (s == "Hello")
                    {
                        Console.WriteLine(dict.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }


    }
}
