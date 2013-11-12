using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0203_Composite.Safe
{

    /// <summary>
    /// 本类是 “安全式的合成模式” 中的 树叶构件（Leaf）角色
    /// </summary>
    public class Leaf : Component
    {
        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="name"></param>
        public Leaf(string name) : base(name) { }


        /// <summary>
        /// 实现父类的 抽象方法.
        /// </summary>
        /// <param name="depth"></param>
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }

    
}
