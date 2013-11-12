using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0071_BlackJack.Service
{

    /// <summary>
    /// 玩家.
    /// </summary>
    public class Player
    {

        /// <summary>
        /// 玩家名称.
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        /// 持有的牌的列表.
        /// </summary>
        protected List<PlayingCards> cardList = new List<PlayingCards>();


        /// <summary>
        /// 取得指定的牌.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PlayingCards GetPlayingCards(int index)
        {
            return cardList[index];
        }

        /// <summary>
        /// 取得牌数.
        /// </summary>
        /// <returns></returns>
        public int GetPlayingCardsCount()
        {
            return cardList.Count;
        }

        /// <summary>
        /// 清除手上的牌.
        /// </summary>
        public void ClearPlayingCards()
        {
            cardList.Clear();
        }



        /// <summary>
        /// 取得玩家点数.
        /// </summary>
        /// <returns></returns>
        public int GetPoint()
        {
            int result = 0;
            foreach (PlayingCards card in cardList)
            {
                result += card.CardRealValue;
            }
            return result;
        }


        /// <summary>
        /// 获取一张牌.
        /// </summary>
        /// <param name="card"></param>
        public void TakeOneCard(PlayingCards card)
        {
            cardList.Add(card);
        }


        /// <summary>
        /// 显示一张牌.
        /// 初始化发牌2张.
        /// 需要显示一张.
        /// </summary>
        /// <param name="card"></param>
        public void ShowOneCard(PlayingCards card)
        {
            foreach (PlayingCards myCard in cardList)
            {
                if (myCard.Equals(card))
                {
                    myCard.IsShowOnTable = true;

                    // 多幅牌的情况下
                    // 万一拿到2张完全一样的
                    // 也是仅仅显示其中的一张.
                    break;
                }
            }
        }


        /// <summary>
        /// 是否不再拿牌。在任何情况下，玩家可选择停止要牌。
        /// </summary>
        public bool IsStand { set; get; }



        /// <summary>
        /// 是否是赢家.
        /// </summary>
        protected bool isWinner;


        /// <summary>
        /// 是否是赢家.
        /// </summary>
        public bool IsWinner
        {
            set
            {
                isWinner = value;
            }
            get
            {
                return isWinner;
            }
        }



        /// <summary>
        /// 重置游戏数据.
        /// </summary>
        public void ResetGameData()
        {
            // 手中的牌清零.
            cardList.Clear();

            // 需要拿牌.
            IsStand = false;

            // 初始化情况下， 不是赢家.
            isWinner = false;
        }



    }

}
