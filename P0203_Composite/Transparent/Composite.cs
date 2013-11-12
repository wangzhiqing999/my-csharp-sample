using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0203_Composite.Transparent
{
    /// <summary>
    /// 本类是 “透明式的合成模式” 中的 树枝构件（Composite）角色
    /// </summary>
    public class Composite : Component
    {

        /// <summary>
        /// 子节点.
        /// </summary>
        private List<Component> children = new List<Component>();

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="name"></param>
        public Composite(string name) : base(name) { }



        /// <summary>
        /// 实现父类的 抽象方法.
        /// </summary>
        /// <param name="c"></param>
        public override void Add(Component c)
        {
            children.Add(c);
        }


        /// <summary>
        /// 实现父类的 抽象方法.
        /// </summary>
        /// <param name="c"></param>
        public override void Remove(Component c)
        {
            children.Remove(c);
        }


        /// <summary>
        /// 实现父类的 抽象方法.
        /// </summary>
        /// <param name="depth"></param>
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            // Display each of the node's children
            foreach (Component component in children)
                component.Display(depth + 2);
        }


    }
}
