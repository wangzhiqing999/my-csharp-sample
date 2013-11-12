using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0308_Memento.SampleChess
{

    /// <summary>
    /// 象棋棋子备忘录类：备忘录
    /// </summary>
    class ChessmanMemento
    {

        public String Label {set;get;}

        public int X {set;get;}

        public int Y {set;get;}

        
        public ChessmanMemento(String label, int x, int y)
        {
            this.Label = label;
            this.X = x;
            this.Y = y;
        }

   
    }


}
