using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A002_OO.CardSample
{

    /// <summary>
    /// 金卡.
    /// </summary>
    class GoldCard : Card
    {

        /// <summary>
        /// 取钱.
        /// </summary>
        public override void TakeMoney()
        {
            Console.WriteLine("从金卡里面取钱！");
        }

        /// <summary>
        /// 排队.
        /// </summary>
        public new void LineUp()
        {
            Console.WriteLine("金卡不排队！");
        }

    }

}
