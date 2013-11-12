using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0203_Composite.Transparent
{
    /// <summary>
    ///  本类是 “透明式的合成模式” 中的 树叶构件（Leaf）角色
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
        /// <param name="c"></param>
        public override void Add(Component c)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("叶子结点无法 追加子节点， 因为不能加！");
            Console.ForegroundColor = oldColor;
        }

        /// <summary>
        /// 实现父类的 抽象方法.
        /// </summary>
        /// <param name="c"></param>
        public override void Remove(Component c)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("叶子结点无法 删除子节点， 因为不存在！");
            Console.ForegroundColor = oldColor;
        }

        /// <summary>
        /// 实现父类的 抽象方法.
        /// </summary>
        /// <param name="c"></param>
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name); 
        }
    }
}
