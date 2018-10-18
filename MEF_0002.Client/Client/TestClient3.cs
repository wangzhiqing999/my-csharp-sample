using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

using MEF_0002.Service;


namespace MEF_0002.Client
{
    public class TestClient3
    {

        /// <summary>
        /// 演示服务列表.
        /// 
        /// 注意：这里传递了参数 FileDemoService,  也就是 指定了 契约名.
        /// 这里是 ImportMany， 因此， 当存在多个的时候， 将获取多个实现.
        /// 
        /// </summary>
        [ImportMany("Path")]
        public IEnumerable<string> Paths { get; set; }



        //导入 无参数， 有返回值方法
        [Import("GetPath")]
        public Func<string> methodWithoutPara { get; set; }


        //导入 有参数， 有返回值方法
        [Import("GetFile")]
        public Func<int, string> methodWithPara { get; set; }


        //导入 无参数， 无返回值方法
        [Import("ShowPath")]
        public Action methodWithoutPara2 { get; set; }


        //导入 有参数， 无返回值方法
        [Import("ShowFile")]
        public Action<int> methodWithPara2 { get; set; }



        public void TestRun()
        {
            foreach (var path in this.Paths)
            {
                Console.WriteLine("属性 Path = {0}", path);
            }
            Console.WriteLine();


            Console.WriteLine("# 调用无参数，有返回值的方法 ");
            if (this.methodWithoutPara != null)
            {
                Console.WriteLine(this.methodWithoutPara());
            }

            Console.WriteLine("# 调用有参数，有返回值的方法 ");
            if (this.methodWithoutPara != null)
            {
                Console.WriteLine(this.methodWithPara(12345));
            }


            Console.WriteLine("# 调用无参数，无返回值的方法 ");
            if (this.methodWithoutPara2 != null)
            {
                this.methodWithoutPara2();
            }

            Console.WriteLine("# 调用有参数，无返回值的方法 ");
            if (this.methodWithoutPara != null)
            {
                this.methodWithPara2(67890);
            }


            Console.WriteLine();
        }

    }
}
