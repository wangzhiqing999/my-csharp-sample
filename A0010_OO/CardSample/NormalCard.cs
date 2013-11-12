using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A002_OO.CardSample
{

    /// <summary>
    /// 普通卡.
    /// </summary>
    class NormalCard : Card
    {

        public override void TakeMoney()
        {
            Console.WriteLine("从普通卡里面取钱！");
        }

    }
}
