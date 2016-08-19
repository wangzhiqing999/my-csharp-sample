using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using B1000_Fody_Cilador.Sample;


namespace B1000_Fody_Cilador
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("测试 Cilador.Fody。    不使用继承， 而重用代码.");



            dynamic test = new NewService();

            
            Console.WriteLine("重用旧的类库的实现1：{0}", test.Hello());
            Console.WriteLine("重用旧的类库的实现2：{0}", test.Hello2());



            Console.WriteLine("自己类中新增加的实现：{0}", test.NewHello());


            Console.ReadKey();
        }


    }
}
