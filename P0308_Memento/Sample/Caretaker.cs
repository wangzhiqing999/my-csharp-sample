using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0308_Memento.Sample
{
    /// <summary>
    /// 管理者类
    /// 
    /// 对于负责人类Caretaker，它用于保存备忘录对象，
    /// 并提供getMemento()方法用于向客户端返回一个备忘录对象，
    /// 原发器通过使用这个备忘录对象可以回到某个历史状态。
    /// 
    /// 
    /// 在Caretaker类中不应该直接调用Memento中的状态改变方法，
    /// 它的作用仅仅用于存储备忘录对象。
    /// 将原发器备份生成的备忘录对象存储在其中，
    /// 当用户需要对原发器进行恢复时再将存储在其中的备忘录对象取出。
    /// 
    /// </summary>
    class Caretaker
    {
        /// <summary>
        /// 得到备忘录
        /// </summary>
        private Memento memento;

        public Memento Memento
        {
            get { return memento; }
            set { memento = value; }
        }
    }
}
