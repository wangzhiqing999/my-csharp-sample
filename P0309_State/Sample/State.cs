using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0309_State.Sample
{
    /// <summary>
    /// 抽象状态类，每个子类实现与Context的一个状态相关的行为
    /// </summary>
    abstract class State
    {
        public abstract void Handle(Context context);
    }
}
