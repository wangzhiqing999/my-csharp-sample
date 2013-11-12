using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0309_State.Sample
{
    class ConcreteStateC : State
    {
        public override void Handle(Context context)
        {
            //状态C的下一状态是状态A
            context.State = new ConcreteStateA();
        }
    }
}
