using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5110_WinFromObserver.Sample
{

    /// <summary>
    /// 具体主题（ConcreteSubject）角色：
    /// 保存对具体观察者对象有用的内部状态；在这种内部状态改变时给其观察者发出一个通知；
    /// 具体主题角色又叫作具体被观察者角色；
    /// 具体主题角色，通常用一个具体子类实现。  
    /// </summary>
    public class ItemManager : ISubject
    {


        //维护QQ群报名参与活动的成员
        List<IObserver> memberList = new List<IObserver>();


        #region ISubject 成员

        /// <summary>
        /// 添加成员.
        /// </summary>
        /// <param name="member"></param>
        public void Attach(IObserver member)
        {
            memberList.Add(member);
        }

        /// <summary>
        /// 移除成员.
        /// </summary>
        /// <param name="member"></param>
        public void Detach(IObserver member)
        {
            memberList.Remove(member);
        }

        /// <summary>
        /// 通知.
        /// </summary>
        public void Notify()
        {
            memberList.ForEach(p => p.GoUpdate());
        }


        /// <summary>
        /// 已选择的数据列表.
        /// </summary>
        public List<int> SelectedItemList
        {
            set;
            get;
        }

        #endregion


    }
}
