using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0308_Memento.SampleChessPlus
{

    /// <summary>
    /// 象棋棋子类：原发器
    /// </summary>
    class Chessman
    {

        public String Label { set; get; }

        public int X { set; get; }

        public int Y { set; get; }



        public Chessman(String label, int x, int y)
        {
            this.Label = label;
            this.X = x;
            this.Y = y;
        }

       


        //保存状态
        public ChessmanMemento save()
        {
            return new ChessmanMemento(this.Label, this.X, this.Y);
        }

        //恢复状态
        public void restore(ChessmanMemento memento)
        {
            this.Label = memento.Label;
            this.X = memento.X;
            this.Y = memento.Y;
        }
    }



    

}
