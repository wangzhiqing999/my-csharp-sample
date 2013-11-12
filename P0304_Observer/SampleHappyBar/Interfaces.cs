using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0304_Observer.SampleHappyBar
{

    /// <summary>
    /// 观察者模式中的  抽象主题（Subject）角色
    /// 
    /// 主题角色把所有的观察者对象的引用保存在一个列表里；
    /// 每个主题都可以有任何数量的观察者。
    /// 主题提供一个接口可以加上或撤销观察者对象；主题角色又叫做抽象被观察者(Observable)角色； 
    /// 抽象主题角色，有时又叫做抽象被观察者角色，可以用一个抽象类或者一个接口实现；在具体的情况下也不排除使用具体类实现。
    /// 
    /// </summary>
    public interface ISubject
    {
        //添加成员
        void Attach(IObserver member);
        //移除成员
        void Detach(IObserver member);
        //通知
        void Notify();
        string PublishInfo { get; set; }
    }



    /// <summary>
    /// 观察者模式中的 抽象观察者（Observer）角色
    /// 
    /// 为所有的具体观察者定义一个接口，在得到通知时更新自己； 
    ///    抽象观察者角色，可以用一个抽象类或者一个接口实现；在具体的情况下也不排除使用具体类实现。  
    /// </summary>
    public interface IObserver
    {
        //根据通知更新自己
        void GoUpdate();
    }

}
