using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace G0071_BlackJack.Service
{
    [TestFixture]
    public class BlackJackGameTest
    {


        [Test]
        public void StartGameTest()
        {
            // 初始化游戏.
            BlackJackGame game = new BlackJackGame();

            // 首先， 新增玩家.
            Player p1 = new Player()
            {
                 Name = "T1",
            };
            bool addNewPlayerresult = game.AddNewPlayer(p1);
            // 结果应该通过.
            Assert.IsTrue(addNewPlayerresult);


            Player p2 = new Player()
            {
                Name = "T2",
            };
            addNewPlayerresult = game.AddNewPlayer(p2);
            // 结果应该通过.
            Assert.IsTrue(addNewPlayerresult);


            // 尝试加入重复的名称.
            Player p3 = new Player()
            {
                Name = "T2",
            };
            addNewPlayerresult = game.AddNewPlayer(p3);
            // 结果应该失败.
            Assert.IsFalse(addNewPlayerresult);




            // 游戏开始以前，玩家手上的点数应该为0
            Assert.AreEqual(0, p1.GetPoint());
            Assert.AreEqual(0, p2.GetPoint());



            // 初始化游戏.
            game.InitGames();

            // 洗牌.
            game.Shuffle();

            // 开始发牌.
            game.StartGame();


            // 发牌以后， 玩家手上的点数应该大于0
            Assert.IsTrue(p1.GetPoint() > 0);
            Assert.IsTrue(p2.GetPoint() > 0);


            // 玩家1，2 都不拿牌了.
            game.PlayerStand(p1);
            game.PlayerStand(p2);


            // 结束游戏.
            game.FinishGame();

            if (p1.GetPoint() > p2.GetPoint())
            {
                // 玩家1分高的情况下，玩家1赢.
                Assert.IsTrue(p1.IsWinner);
                Assert.IsFalse(p2.IsWinner);
            }
            else if (p1.GetPoint() < p2.GetPoint())
            {
                // 玩家2分高的情况下，玩家2赢.
                Assert.IsTrue(p2.IsWinner);
                Assert.IsFalse(p1.IsWinner);
            }
            else
            {
                // 相同的情况下，认为都赢了.
                Assert.IsTrue(p1.IsWinner);
                Assert.IsTrue(p2.IsWinner);
            }




        }


    }

}
