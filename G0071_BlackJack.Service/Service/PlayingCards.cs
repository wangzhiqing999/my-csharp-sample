using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0071_BlackJack.Service
{

    /// <summary>
    /// 花色.
    /// </summary>
    public enum Suit
    {
        /// <summary>
        /// 黑桃
        /// </summary>
        Spades = 1,

        /// <summary>
        /// 红心
        /// </summary>
        Hearts = 2,

        /// <summary>
        /// 梅花
        /// </summary>
        Clubs = 3,

        /// <summary>
        /// 方块.
        /// </summary>
        Diamonds = 4,
    }






    /// <summary>
    /// 一张扑克牌.
    /// </summary>
    public class PlayingCards
    {
        /// <summary>
        /// 牌的显示.
        /// </summary>
        public static string[] CardDisplayArray = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", };

        private static Dictionary<string, int> cardPointDictionary;
        static PlayingCards() {
            cardPointDictionary = new Dictionary<string, int>();
            cardPointDictionary.Add("A", 1);
            for (int i = 2; i <= 10; i++)
            {
                cardPointDictionary.Add(i.ToString(), i);
            }
            cardPointDictionary.Add("J", 10);
            cardPointDictionary.Add("Q", 10);
            cardPointDictionary.Add("K", 10);
        }


        /// <summary>
        /// 花色.
        /// </summary>
        public Suit Suit { set; get; }


        /// <summary>
        /// 显示用的数值.
        /// </summary>
        private string cardDisplayValue;

        public string CardDisplayValue
        {
            set {
                if (!cardPointDictionary.ContainsKey(value))
                {
                    throw new ArgumentException("无法识别的扑克牌:" + value);
                }
                this.cardDisplayValue = value;
            }
            get
            {
                return this.cardDisplayValue;
            }
        }


        /// <summary>
        /// 卡片实际数值.
        /// </summary>
        public int CardRealValue
        {
            get
            {
                if (string.IsNullOrEmpty(cardDisplayValue))
                {
                    // 空白卡片.
                    return 0;
                }

                if (!cardPointDictionary.ContainsKey(cardDisplayValue))
                {
                    // 未知的卡片.
                    return 0;
                }

                return cardPointDictionary[cardDisplayValue];
            }
        }



        /// <summary>
        /// 明牌/牌底.
        /// </summary>
        public bool IsShowOnTable { set; get; }



        /// <summary>
        /// 比较两张牌是否一致.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is PlayingCards))
            {
                // 数据类型不一致，直接返回.
                return false;
            }

            // 类型装换.
            PlayingCards card = obj as PlayingCards;

            if (card.Suit != this.Suit)
            {
                // 花色不一致.
                return false;
            }

            if (card.cardDisplayValue != this.cardDisplayValue)
            {
                // 点数不一致.
                return false;
            }

            // 数据类型、花色、点数都一致.
            return true;
        }


        /// <summary>
        /// Hash 值 = 花色*100 + 点数
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int result = Convert.ToInt32(this.Suit)  * 100;
            result += Array.IndexOf(CardDisplayArray, this.cardDisplayValue);
            return result;
        }

        /// <summary>
        /// 调试输出用.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();
            buff.Append(this.Suit);
            buff.Append(this.cardDisplayValue);
            return buff.ToString();
        }
    }

}
