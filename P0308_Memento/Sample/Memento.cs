using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0308_Memento.Sample
{

    /// <summary>
    /// 备忘录类
    /// </summary>
    class Memento
    {
        private string _state;

        public Memento(string state)
        {
            this._state = state;
        }

        public string State
        {
            get { return _state; }
        }
    }

}
