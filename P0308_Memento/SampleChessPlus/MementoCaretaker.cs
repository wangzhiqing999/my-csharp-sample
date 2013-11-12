using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0308_Memento.SampleChessPlus
{

    /// <summary>
    /// 象棋棋子备忘录管理类：负责人
    /// </summary>
    class MementoCaretaker
    {

        //定义一个集合来存储多个备忘录
        private List<ChessmanMemento> mementolist = new List<ChessmanMemento>();

        public ChessmanMemento getMemento(int i)
        {
            return mementolist[i];
        }

        public void setMemento(ChessmanMemento memento)
        {
            mementolist.Add(memento);
        }
    }

}
