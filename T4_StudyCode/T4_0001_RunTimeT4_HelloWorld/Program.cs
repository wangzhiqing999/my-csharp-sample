using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4_0001_RunTimeT4_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            // 注： 这里的类名， 就是那个 t4 模板的文件名.
            // 因此，创建模板的时候， 名字不要瞎起.
            HelloWorld tester = new HelloWorld();
            String result = tester.TransformText();
            Console.WriteLine(result);


            Console.WriteLine("------------------------------");


            HelloWorldWithParam tester2 = new HelloWorldWithParam("My Hello World!");
            result = tester2.TransformText();
            Console.WriteLine(result);


            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }


    /// <summary>
    /// 自己为 T4 模板，增加外部传入的参数.
    /// </summary>
    partial class HelloWorldWithParam
    {
        private string m_data;
        public HelloWorldWithParam(string data) { this.m_data = data; }
    }
}
