using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0309_State.Sample
{
    class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            //设置状态A的下一状态是状态B
            context.State = new ConcreteStateB();
        }
    }
}
