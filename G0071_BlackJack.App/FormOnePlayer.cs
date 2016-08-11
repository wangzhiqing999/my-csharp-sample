using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using G0071_BlackJack.Service;


namespace G0071_BlackJack.App
{
    public partial class FormOnePlayer : Form
    {
        public FormOnePlayer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 默认玩家名.
        /// </summary>
        private const string DEFAULT_PLAYER_NAME = "User";


        /// <summary>
        /// 默认电脑玩家名.
        /// </summary>
        private const string DEFAULT_COMPUTER_PLAYER_NAME = "PC";


        /// <summary>
        /// 游戏类.
        /// </summary>
        private BlackJackGame game;


        /// <summary>
        /// 玩家.
        /// </summary>
        private Player player;


        /// <summary>
        /// 电脑玩家.
        /// </summary>
        private ComputerPlayer computerPlayer;



        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOnePlayer_Load(object sender, EventArgs e)
        {
            // 初始化游戏类.
            game = new BlackJackGame();

            // 初始化玩家.
            player = new Player()
            {
                Name = DEFAULT_PLAYER_NAME,
            };
            computerPlayer = new ComputerPlayer()
            {
                Name = DEFAULT_COMPUTER_PLAYER_NAME,
            };

            // 玩家加入游戏.
            game.AddNewPlayer(player);
            game.AddNewPlayer(computerPlayer);

            // 初始化游戏.
            //game.InitGames();


            // 事件绑定.
            // 当2张牌发完以后， 显示牌局.
            game.AfterTakeFirstTwoCard += new AfterTakeFirstTwoCardHandler(ShowAfterTakeFirstTwoCard);
        }

        /// <summary>
        /// 关闭.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOnePlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain formMain = FormMain.GetFormMain();
            formMain.Show();
        }



        /// <summary>
        /// 开始游戏.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            game.InitGames();

            // 洗牌.
            game.Shuffle();

            // 开始发牌.
            game.StartGame();

            // 开始以后，本按钮不可按.
            btnStart.Visible = false;

            this.btnHit.Visible = true;
            this.btnStand.Visible = true;


            lblResult.Text = String.Empty;


            // 初始情况下， 始终要求拿牌.
            player.IsStand = false;
        }



        /// <summary>
        /// 要牌.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHit_Click(object sender, EventArgs e)
        {
            // 玩家要牌.
            game.PlayerHit(player);


            // 显示新加的牌.
            PlayingCards card = player.GetPlayingCards(player.GetPlayingCardsCount() - 1);
            card.IsShowOnTable = true;
            tlpUser.Controls.Add(GetDisplayPicBox(card));

            if (player.IsStand)
            {
                btnHit.Visible = false;
            }
        }


        /// <summary>
        /// 结束要牌.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStand_Click(object sender, EventArgs e)
        {                        
            // 玩家结束.
            game.PlayerStand(player);


            // 电脑玩家结束处理.
            computerPlayer.DoAutoHitOrStand(game);

            // 显示计算机玩家的所有牌
            ShowComputerAllCards();


            this.btnHit.Visible = false;
            this.btnStand.Visible = false;
            this.btnStart.Visible = true;

            // 完成游戏.
            game.FinishGame();

            // 显示游戏结果.
            ShowGameResult();
        }




        /// <summary>
        /// 显示玩家与电脑的牌.
        /// </summary>
        private void ShowAfterTakeFirstTwoCard()
        {
            // 清除已有的图片
            tlpComputer.Controls.Clear();

            PlayingCards c1 = computerPlayer.GetPlayingCards(0);
            c1.IsShowOnTable = false;
            tlpComputer.Controls.Add(GetDisplayPicBox(c1));

            PlayingCards c2 = computerPlayer.GetPlayingCards(1);
            c2.IsShowOnTable = true;
            tlpComputer.Controls.Add(GetDisplayPicBox(c2));



            // 清除已有的图片
            tlpUser.Controls.Clear();

            for (int i = 0; i < 2; i++)
            {
                PlayingCards card = player.GetPlayingCards(i);
                card.IsShowOnTable = true;
                tlpUser.Controls.Add(GetDisplayPicBox(card));
            }

        }




        /// <summary>
        /// 显示计算机玩家的所有牌.
        /// </summary>
        private void ShowComputerAllCards()
        {
            // 清除已有的图片
            tlpComputer.Controls.Clear();

            for (int i = 0; i < computerPlayer.GetPlayingCardsCount(); i++)
            {
                PlayingCards card = computerPlayer.GetPlayingCards(i);
                card.IsShowOnTable = true;
                tlpComputer.Controls.Add(GetDisplayPicBox(card));
            }
        }





        /// <summary>
        /// 取得指定牌的图片.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private PictureBox GetDisplayPicBox(PlayingCards card)
        {
            string fileName = @"pic\BackGround.jpg";

            if (card.IsShowOnTable)
            {
                // 牌是要显示正面的.
                fileName = String.Format(@"pic\{0}_{1}.jpg",
                    card.Suit, card.CardDisplayValue);
            }

            PictureBox result = new PictureBox()
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = new Bitmap(fileName),
            };

            return result;
        }




        /// <summary>
        /// 显示游戏结果.
        /// </summary>
        private void ShowGameResult()
        {
            

            // 预期结果.
            StringBuilder buff = new StringBuilder();

            buff.AppendFormat("电脑：{0}", computerPlayer.GetPoint());            
            buff.AppendLine();
            if (computerPlayer.IsWinner)
            {
                buff.AppendLine("Win!");
            }
            else
            {
                buff.AppendLine("Lose!");
            }
            buff.AppendLine();




            buff.AppendFormat("玩家：{0}", player.GetPoint());
            buff.AppendLine();
            if (player.IsWinner)
            {
                buff.AppendLine("Win!");
            }
            else
            {
                buff.AppendLine("Lose!");
            }
            buff.AppendLine();



            this.lblResult.Text = buff.ToString();
        }




    }
}
