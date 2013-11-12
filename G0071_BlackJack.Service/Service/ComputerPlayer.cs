using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0071_BlackJack.Service
{

    /// <summary>
    /// 计算机玩家.
    /// </summary>
    public class ComputerPlayer : Player
    {


        /// <summary>
        /// 自动完成 要牌或者停止要牌的处理.
        /// </summary>
        public void DoAutoHitOrStand(BlackJackGame game)
        {
            // 如果当前分数小于13，那么尝试拿牌.

            while (this.GetPoint() < 13)
            {
                // 拿牌.
                game.PlayerHit(this);
            }

            // 拿牌完毕后.
            game.PlayerStand(this);
        }

    }


}
