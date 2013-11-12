using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0203_Composite.Transparent
{
    /// <summary>
    /// 本类是 “透明式的合成模式” 中的 抽象构件(Component)角色
    /// </summary>
    public abstract class Component
    {
        /// <summary>
        /// 名称变量.
        /// </summary>
        protected string name;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="name"></param>
        public Component(string name)
        {
            this.name = name;
        }


        /// <summary>
        /// 抽象的方法
        /// 
        /// 追加叶子结点.
        /// </summary>
        /// <param name="c"></param>
        public abstract void Add(Component c);


        /// <summary>
        /// 抽象的方法
        /// 
        /// 删除叶子结点.
        /// </summary>
        /// <param name="c"></param>
        public abstract void Remove(Component c);


        /// <summary>
        /// 抽象的方法
        /// 
        /// 用于显示 合成对象的信息。
        /// </summary>
        /// <param name="depth"></param>
        public abstract void Display(int depth);
    }
}
