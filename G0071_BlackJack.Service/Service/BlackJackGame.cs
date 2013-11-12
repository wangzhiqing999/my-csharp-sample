using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0071_BlackJack.Service
{

    /// <summary>
    /// 开始洗牌的委托.
    /// </summary>
    public delegate void BeforeShuffleHandler();

    /// <summary>
    /// 结束洗牌的委托.
    /// </summary>
    public delegate void AfterShuffleHandler();




    /// <summary>
    /// 给指定玩家  发指定的牌的 委托处理.
    /// </summary>
    /// <param name="player"> 玩家 </param>
    public delegate void BeforeTakeOneCardHandler(Player player, ref bool cancel);

    /// <summary>
    /// 给指定玩家  发指定的牌的 委托处理.
    /// </summary>
    /// <param name="player"> 玩家 </param>
    /// <param name="card"> 牌 </param>
    public delegate void AfterTakeOneCardHandler(Player player, PlayingCards card);





    /// <summary>
    /// 当发完前2张牌的情况下， 处理的委托.
    /// </summary>
    public delegate void AfterTakeFirstTwoCardHandler();









    public class BlackJackGame
    {
        /// <summary>
        /// 开始洗牌的事件.
        /// </summary>
        public event BeforeShuffleHandler BeforeShuffle;

        /// <summary>
        /// 结束洗牌的事件.
        /// </summary>
        public event AfterShuffleHandler AfterShuffle;


        /// <summary>
        /// 开始给指定玩家  发指定的牌的事件
        /// </summary>
        public event BeforeTakeOneCardHandler BeforeTakeOneCard;

        /// <summary>
        /// 结束给指定玩家  发指定的牌的事件
        /// </summary>
        public event AfterTakeOneCardHandler AfterTakeOneCard;



        /// <summary>
        /// 定义事件.
        /// </summary>
        public event AfterTakeFirstTwoCardHandler AfterTakeFirstTwoCard;





        /// <summary>
        /// 最多允许使用多少幅牌.
        /// </summary>
        private const int MAX_NUM_OF_DECK = 8;


        /// <summary>
        /// 最多允许多少个玩家.
        /// </summary>
        private const int MAX_NUM_OF_PLAYER = 6;


        /// <summary>
        /// 最大点数 = 21点.
        /// </summary>
        private const int MAX_POINT = 21;


        /// <summary>
        /// 总共使用几副牌
        /// </summary>
        private int numOfDeck = 1;

        /// <summary>
        /// 总共使用几副牌（1-8副）
        /// </summary>
        public int NumOfDeck {
            set
            {
                numOfDeck = value;
                if (numOfDeck < 1)
                {
                    // 小于1的情况下， 设置为1.
                    numOfDeck = 1;
                }
                if (numOfDeck > MAX_NUM_OF_DECK)
                {
                    // 大于8的情况下， 设置为8.
                    numOfDeck = MAX_NUM_OF_DECK;
                }
            }
            get
            {
                return numOfDeck;
            }
        }




        /// <summary>
        /// 总共多少个玩家. (注： 这里的玩家不包括电脑)
        /// </summary>
        private int numOfPlayer = 1;

        /// <summary>
        /// 总共多少个玩家 (注： 这里的玩家不包括电脑)
        /// </summary>
        public int NumOfPlayer
        {
            set
            {
                numOfPlayer = value;
                if (numOfPlayer < 1)
                {
                    // 小于1的情况下， 设置为1.
                    numOfPlayer = 1;
                }
                if (numOfPlayer > MAX_NUM_OF_PLAYER)
                {
                    // 大于6的情况下， 设置为6.
                    numOfPlayer = MAX_NUM_OF_PLAYER;
                }
            }
            get
            {
                return numOfPlayer;
            }
        }



        /// <summary>
        /// 全部的牌列表
        /// </summary>
        private List<PlayingCards> allPlayingCards = new List<PlayingCards>();


        /// <summary>
        /// 洗牌好以后的 队列.
        /// </summary>
        private Queue<PlayingCards> playingCardsQueue = new Queue<PlayingCards>();


        /// <summary>
        /// 玩家列表.
        /// </summary>
        private List<Player> playerList = new List<Player>();


        /// <summary>
        /// 初始化.
        /// </summary>
        public void InitGames()
        {
            allPlayingCards.Clear();
            // 有几副牌， 就加几副.
            for (int i = 0; i < numOfDeck; i++)
            {
                PlayingDeck deck = new PlayingDeck();
                allPlayingCards.AddRange(deck.PlayingCardsList);
            }
        }


        /// <summary>
        /// 新增玩家.
        /// </summary>
        /// <param name="player"></param>
        public bool AddNewPlayer(Player player)
        {
            if (player == null)
            {
                // 忽略为 Null 的玩家.
                return false;
            }

            if (playerList.Count >= MAX_NUM_OF_PLAYER)
            {
                // 不允许超过最大玩家数量.
                return false;
            }

            if (playerList.Count(p => p.Name == player.Name) > 0)
            {
                // 不允许重复名字.
                return false;
            }

            // 加入列表并返回.
            playerList.Add(player);

            return true;
        }



        /// <summary>
        /// 洗牌.
        /// </summary>
        public void Shuffle()
        {
            // 开始洗牌事件.
            if (BeforeShuffle != null)
            {
                BeforeShuffle();
            }


            // 清空队列.
            playingCardsQueue.Clear();

            // 现有扑克牌随机排序.
            var query =
                from data in allPlayingCards
                orderby Guid.NewGuid()
                select data;





            // 加入队列.
            foreach (PlayingCards card in query)
            {
                playingCardsQueue.Enqueue(card);
            }



            // 结束洗牌事件.
            if (AfterShuffle != null)
            {
                AfterShuffle();
            }
        }




        /// <summary>
        /// 开始发牌.
        /// </summary>
        public void StartGame()
        {

            // 遍历每一个玩家.
            foreach (Player player in playerList)
            {
                // 首先清理掉手上的牌.
                player.ClearPlayingCards();
            }


            // 初始情况下，发2张牌.
            for (int i = 0; i < 2; i++)
            {
                // 遍历每一个玩家.
                foreach (Player player in playerList)
                {
                    // 根据需要， 触发事件.
                    bool bCancel = false;
                    if (BeforeTakeOneCard != null)
                    {
                        BeforeTakeOneCard(player, ref bCancel);
                    }

                    // 扑克牌出队列.
                    PlayingCards card = playingCardsQueue.Dequeue();

                    // 扑克牌给玩家.
                    player.TakeOneCard(card);


                    // 根据需要， 触发事件.
                    if (AfterTakeOneCard != null)
                    {
                        AfterTakeOneCard(player, card);
                    }
                }
            }


            // 触发事件.
            if (AfterTakeFirstTwoCard != null)
            {
                AfterTakeFirstTwoCard();
            }
        }







        /// <summary>
        /// 玩家 再拿一张牌。
        /// 玩家（包括闲家和庄家）只要手上牌相加点数不超过21点都可要牌。
        /// </summary>
        /// <param name="player"></param>
        public void PlayerHit(Player player)
        {
            if (player.GetPoint() <= MAX_POINT)
            {

                bool bCancel = false;
                // 根据需要， 触发事件.
                if (BeforeTakeOneCard != null)
                {
                    BeforeTakeOneCard(player, ref bCancel);
                }


                // 扑克牌出队列.
                PlayingCards card = playingCardsQueue.Dequeue();

                // 后续发的牌， 都要显示了.
                card.IsShowOnTable = true;                

                // 扑克牌给玩家.
                player.TakeOneCard(card);



                // 根据需要， 触发事件.
                if (AfterTakeOneCard != null)
                {
                    AfterTakeOneCard(player, card);
                }


                if (player.GetPoint() >= MAX_POINT)
                {
                    // 暴了.
                    player.IsStand = true;
                }
            }
        }



        /// <summary>
        /// 玩家 不再拿牌。在任何情况下，玩家可选择停止要牌。
        /// </summary>
        /// <param name="player"></param>
        public void PlayerStand(Player player)
        {
            player.IsStand = true;
        }




        /// <summary>
        /// 完成游戏.
        /// </summary>
        public void FinishGame()
        {
            var query =
                from data in playerList
                where data.GetPoint() <= MAX_POINT
                orderby data.GetPoint() descending
                select data;

            if (query.Count() == 0)
            {
                // 都暴了.
                // 遍历每一个玩家.
                foreach (Player player in playerList)
                {
                    player.IsWinner = false;
                }
            }
            else if (query.Count() == 1)
            {
                Player winner = query.First();
                winner.IsWinner = true;

                // 只剩下一个没有暴.
                foreach (Player player in playerList)
                {
                    if (player.Name == winner.Name
                        && player.GetPoint() == winner.GetPoint())
                    {
                        // 这个是赢家.
                        continue;
                    }
                    player.IsWinner = false;
                }
            }
            else
            {
                // 剩下的情况， 是存在多个玩家没有暴仓的情况下.

                // 排名第一的肯定是赢家.
                Player winner = query.First();
                winner.IsWinner = true;

                
                foreach (Player player in playerList)
                {
                    if (player.Name == winner.Name
                        && player.GetPoint() == winner.GetPoint())
                    {
                        // 这个是赢家.
                        continue;
                    }
                    else if (!player.IsWinner 
                      && player.GetPoint() == winner.GetPoint())
                    {
                        // 点数与赢家一样，那么也是赢家.
                        player.IsWinner = true;
                        continue;
                    }

                    player.IsWinner = false;
                }
            }
        }


    }
}
