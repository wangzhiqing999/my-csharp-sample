using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0308_Memento.Sample
{
    class Demo
    {
        public static void ShowDemo()
        {
            Console.WriteLine("测试备忘录模式");


            Console.WriteLine("====== 初始状态 ======");

            Originator o = new Originator();
            o.State = "On"; //初始状态
            o.Show();



            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();//保存状态


            Console.WriteLine("====== 状态改变 ======");
            o.State = "Off"; //状态改变为Off
            o.Show();


            o.SetMemento(c.Memento);//恢复原始状态
            o.Show();


        }
    }
}
