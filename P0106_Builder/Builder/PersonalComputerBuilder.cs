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
    /// 本例子用于 具体建造一台个人计算机
    /// </summary>
    public class PersonalComputerBuilder : IComputerBuilder
    {

        /// <summary>
        /// 预期建筑的结果.
        /// </summary>
        private PersonalComputer product = new PersonalComputer();


        void IComputerBuilder.BuildHardward()
        {
            product.Hardward = "英特尔i7CPU 8G内存 华硕主板......";
        }

        void IComputerBuilder.BuildSoftware()
        {
            product.Software = "Windows 8 客户预览版 64位";
        }

        Product.AbstractComputer IComputerBuilder.BuildComputer()
        {
            return product;
        }
    }

}
