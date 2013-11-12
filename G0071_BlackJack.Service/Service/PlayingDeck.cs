using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0071_BlackJack.Service
{

    /// <summary>
    /// 一副扑克牌.
    /// </summary>
    public class PlayingDeck
    {
        /// <summary>
        /// 扑克牌列表.
        /// </summary>
        private List<PlayingCards> playingCardsList;

        /// <summary>
        /// 扑克牌列表
        /// </summary>
        public List<PlayingCards> PlayingCardsList
        {
            get
            {
                return playingCardsList;
            }
        }


        /// <summary>
        /// 构造函数.
        /// </summary>
        public PlayingDeck()
        {
            // 初始化排列表.
            playingCardsList = new List<PlayingCards>();

            foreach (string val in PlayingCards.CardDisplayArray)
            {
                // 黑桃.
                PlayingCards card1 = new PlayingCards()
                {
                     Suit = Suit.Spades,
                     CardDisplayValue = val,
                };
                playingCardsList.Add(card1);

                // 红心
                PlayingCards card2 = new PlayingCards()
                {
                    Suit = Suit.Hearts,
                    CardDisplayValue = val,
                };
                playingCardsList.Add(card2);
                
                // 梅花.
                PlayingCards card3 = new PlayingCards()
                {
                    Suit = Suit.Clubs,
                    CardDisplayValue = val,
                };
                playingCardsList.Add(card3);

                // 方块.
                PlayingCards card4 = new PlayingCards()
                {
                    Suit = Suit.Diamonds,
                    CardDisplayValue = val,
                };
                playingCardsList.Add(card4);
            }
        }


    }
}
