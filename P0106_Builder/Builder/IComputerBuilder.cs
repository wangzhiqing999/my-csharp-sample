using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0106_Builder.Product;


namespace P0106_Builder.Builder
{

    /// <summary>
    /// 这是 建造模式中的  抽象建造者。
    /// 这里规范定义了产品对象的各个组成成分的建造。
    /// 
    /// 本例子用于 构造一台计算机。
    /// </summary>
    public interface IComputerBuilder
    {
        /// <summary>
        /// 建造硬件.
        /// </summary>
        void BuildHardward();


        /// <summary>
        /// 建造软件.
        /// </summary>
        void BuildSoftware();


        /// <summary>
        /// 建造计算机.
        /// </summary>
        /// <returns></returns>
        AbstractComputer BuildComputer();
    }

}
