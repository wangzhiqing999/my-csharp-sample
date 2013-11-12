using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0203_Composite.Safe
{
    /// <summary>
    /// 本类是 “安全式的合成模式” 中的 树枝构件（Composite）角色
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


        #region  树枝构件（Composite）角色  独有的方法 (叶子结点没有的)

        /// <summary>
        /// 新增.
        /// </summary>
        /// <param name="component"></param>
        public void Add(Component component)
        {
            children.Add(component);
        }

        /// <summary>
        /// 删除.
        /// </summary>
        /// <param name="component"></param>
        public void Remove(Component component)
        {
            children.Remove(component);
        }


        #endregion



        /// <summary>
        /// 实现父类的 抽象方法.
        /// </summary>
        /// <param name="depth"></param>
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // 显示所有的子结点.
            foreach (Component component in children)
                component.Display(depth + 2);
        }
    }
}
