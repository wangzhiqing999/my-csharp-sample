using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using P0106_Builder.Product;
using P0106_Builder.Builder;
using P0106_Builder.Director;



namespace P0106_Builder
{
    class Program
    {
        static void Main(string[] args)
        {

            TestMini();


            TestPersonal();


            Console.ReadLine();
        }



        private static void TestMini()
        {
            // 这里手动构造了 具体建造者
            MiniComputerBuilder mcb = new MiniComputerBuilder();

            // 构造  Director（指挥者）
            // 通过 构造函数  注入 具体建造者
            ComputerDiector cd = new ComputerDiector(mcb);

            // 构造一台计算机.
            AbstractComputer ac = cd.BuildComputer();

            // 测试 构造结果.
            ac.StartComputer();
        }


        private static void TestPersonal()
        {
            // 这里手动构造了 具体建造者
            PersonalComputerBuilder pcb = new PersonalComputerBuilder();

            // 构造  Director（指挥者）
            // 通过 构造函数  注入 具体建造者
            ComputerDiector cd = new ComputerDiector(pcb);

            // 构造一台计算机.
            AbstractComputer ac = cd.BuildComputer();

            // 测试 构造结果.
            ac.StartComputer();
        }


    }
}
