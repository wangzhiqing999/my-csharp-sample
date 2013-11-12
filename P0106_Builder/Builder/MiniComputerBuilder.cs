using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using P0106_Builder.Product;


namespace P0106_Builder.Builder
{


    /// <summary>
    /// 这是 建造模式中的  ConcreteBuilder（具体建造者）
    /// 
    /// 本例子用于 具体建造一台小型计算机
    /// </summary>
    public class MiniComputerBuilder : IComputerBuilder
    {

        /// <summary>
        /// 预期建筑的结果.
        /// </summary>
        private MiniComputer product = new MiniComputer();


        void IComputerBuilder.BuildHardward()
        {
            product.Hardward = "小型机的CPU;内存;主板等......";
        }

        void IComputerBuilder.BuildSoftware()
        {
            product.Software = "Unix";
        }

        Product.AbstractComputer IComputerBuilder.BuildComputer()
        {
            return product;
        }
    }

}
