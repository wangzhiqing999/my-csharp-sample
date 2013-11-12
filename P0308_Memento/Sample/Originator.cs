using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0308_Memento.Sample
{
    /// <summary>
    /// 发起人类
    /// </summary>
    class Originator
    {

        /// <summary>
        /// 需要保存的属性
        /// </summary>
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        /// <summary>
        /// 创建备忘录，将当前需要保存的信息导入并实例化一个Memento对象
        /// </summary>
        /// <returns></returns>
        public Memento CreateMemento()
        {
            return (new Memento((state)));
        }
        /// <summary>
        /// 恢复备忘录模式，将Memento导入并将相关数据恢复
        /// </summary>
        /// <param name="memento"></param>
        public void SetMemento(Memento memento)
        {
            state = memento.State;
        }
        /// <summary>
        /// 显示状态
        /// </summary>
        public void Show()
        {
            Console.WriteLine("State=" + state);
        }

    }

}
