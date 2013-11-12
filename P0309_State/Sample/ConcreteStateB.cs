using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0309_State.Sample
{
    class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            // 状态B的下一状态是状态C
            context.State = new ConcreteStateC();
        }
    }
}
