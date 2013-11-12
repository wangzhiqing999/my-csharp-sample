using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0308_Memento.SampleChess
{

    /// <summary>
    /// 象棋棋子备忘录管理类：负责人
    /// </summary>
    class MementoCaretaker
    {

        private ChessmanMemento memento;

        public ChessmanMemento getMemento()
        {
            return memento;
        }

        public void setMemento(ChessmanMemento memento)
        {
            this.memento = memento;
        }
    }

}
