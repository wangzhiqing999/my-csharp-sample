using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0308_Memento.SampleChessPlus
{
    class Demo
    {

        private static int index = -1; //定义一个索引来记录当前状态所在位置

        private static MementoCaretaker mc = new MementoCaretaker();


        public static void ShowDemo()
        {
            Console.WriteLine("测试备忘录模式 --- 象棋的例子 (支持多次 UNDO 与 REDO) ");

            Chessman chess = new Chessman("车", 1, 1);
            Play(chess);

            chess.Y = 4;
            Play(chess);

            chess.X = 5;
            Play(chess);

            Undo(chess, index);
            Undo(chess, index);

            Redo(chess, index);
            Redo(chess, index);  

        }



        //下棋
        public static void Play(Chessman chess) {
		mc.setMemento(chess.save()); //保存备忘录
		index ++; 
		Console.WriteLine ("棋子" + chess.Label + "当前位置为：" + "第" + chess.X + "行" + "第" + chess.Y + "列。");
	}

        //悔棋
        public static void Undo(Chessman chess, int i) {
		Console.WriteLine ("******悔棋******");
		index --; 
		chess.restore(mc.getMemento(i-1)); //撤销到上一个备忘录
        Console.WriteLine("棋子" + chess.Label + "当前位置为：" + "第" + chess.X + "行" + "第" + chess.Y + "列。");
	}

        //撤销悔棋
        public static void Redo(Chessman chess, int i) {
		Console.WriteLine ("******撤销悔棋******");	
		index ++; 
		chess.restore(mc.getMemento(i+1)); //恢复到下一个备忘录
        Console.WriteLine("棋子" + chess.Label + "当前位置为：" + "第" + chess.X + "行" + "第" + chess.Y + "列。");
	}

    }
}
