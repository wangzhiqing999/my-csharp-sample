using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0308_Memento.SampleChess
{
    class Demo
    {

        public static void ShowDemo()
        {
            Console.WriteLine("测试备忘录模式 --- 象棋的例子");

            MementoCaretaker mc = new MementoCaretaker();
		    
            Chessman chess = new Chessman("车",1,1);
		    display(chess);

		    mc.setMemento(chess.save()); //保存状态		

		    chess.Y = 4;
		    display(chess);

		    mc.setMemento(chess.save()); //保存状态
		    display(chess);

		    chess.X = 5;
		    display(chess);

		    Console.WriteLine("******悔棋******");

		    chess.restore(mc.getMemento()); //恢复状态
		    display(chess);
        }



      	public static void display(Chessman chess) {
		    Console.WriteLine("棋子" + chess.Label + "当前位置为：" + "第" + chess.X + "行" + "第" + chess.Y + "列。");
	    }
    }
}
