using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using P0106_Builder.Builder;
using P0106_Builder.Product;


namespace P0106_Builder.Director
{

    /// <summary>
    /// 这是 建造模式中的  Director（指挥者）
    /// 
    /// 客户端一般只需要与指挥者进行交互。
    /// </summary>
    public class ComputerDiector
    {

        /// <summary>
        /// Builder（抽象建造者）
        /// </summary>
        private IComputerBuilder computerBuilder;

        /// <summary>
        /// 构造函数 依赖注入的方式。
        /// 选择 特定的 ConcreteBuilder（具体建造者）
        /// </summary>
        /// <param name="icb"></param>
        public ComputerDiector(IComputerBuilder icb)
        {
            this.computerBuilder = icb;
        }



        /// <summary>
        /// 构造一台 计算机.
        /// </summary>
        /// <returns></returns>
        public AbstractComputer BuildComputer()
        {

            // 安装硬件.
            Console.WriteLine("Director 指挥安装硬件！");
            computerBuilder.BuildHardward();


            // 安装软件.
            Console.WriteLine("Director 指挥安装软件！");
            computerBuilder.BuildSoftware();


            // 返回 装好的机器.
            Console.WriteLine("Director 指挥安装完毕！");
            return computerBuilder.BuildComputer();
        }

    }
}
