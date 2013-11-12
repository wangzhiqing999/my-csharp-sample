using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


using G0051_Jigsaw.Service;


namespace G0051_Jigsaw.App
{
    public partial class Form3x3 : Form
    {
        public Form3x3()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 拼图主数据.
        /// </summary>
        private Puzzle8 puzzle8 = new Puzzle8();


        /// <summary>
        /// 开始时间.
        /// </summary>
        private DateTime startTime;


        /// <summary>
        /// 开始.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            // 初始化拼图主数据.
            puzzle8.InitPuzzle();

            while (!puzzle8.HaveSolution())
            {
                // 如果无解，那么重新生成随机数据.
                puzzle8.InitPuzzle();
            }


            // 事件绑定.
            puzzle8.Moving += new MovingHandler(NumberItemMoving);


            // 删除 表格中所有 已存在的按钮.
            this.tlpMain.Controls.Clear();

            // 填充表格.
            for (int i = 0; i < puzzle8.PuzzleSize; i++)
            {
                for (int j = 0; j < puzzle8.PuzzleSize; j++)
                {
                    if (i == puzzle8.PuzzleSize - 1 && j == puzzle8.PuzzleSize - 1)
                    {
                        // 0 不处理.
                        break;
                    }

                    Button btnNumber = new Button()
                    {
                        // 填充方式.
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        Text = puzzle8[i,j].ToString(),
                        UseVisualStyleBackColor = true
                    };

                    // 按钮点击.
                    btnNumber.Click += new System.EventHandler(this.btnNumber_Click);

                    // 按钮加入 Table.
                    // 注意参数的顺序：  先列 后行.
                    this.tlpMain.Controls.Add(btnNumber, j, i);
                }
            }


            // 允许自动处理.
            btnAutoProcess.Enabled = true;


            // 开始计时.
            startTime = DateTime.Now;
            timer1.Start();
        }


        /// <summary>
        /// 自动处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoProcess_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                puzzle8.AutoMove();
            }).Start();

            // 开始自动处理.
            BeginAuto();
        }



        /// <summary>
        /// 按钮事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNumber_Click(object sender, EventArgs e)
        {
            // 获取被点击的按钮.
            Button btn = sender as Button;

            int row = this.tlpMain.GetRow(btn);
            int col = this.tlpMain.GetColumn(btn);

            // 拼图移动.
            puzzle8.Move(row, col);


            // 手动点击后， 不允许按自动了.
            btnAutoProcess.Enabled = false;
        }


        /// <summary>
        /// 数字单元移动.
        /// </summary>
        /// <param name="step"></param>
        /// <param name="direction"></param>
        private void NumberItemMoving(MoveStep step, MoveDirection direction)
        {

            Invoke(new Action(() =>
                            {

                                // 取得指定坐标的 按钮控件.
                                // 注意参数的顺序， 先列后行!
                                Control ctl = this.tlpMain.GetControlFromPosition(step.J, step.I);

                                // 将按钮从表格删除.
                                this.tlpMain.Controls.Remove(ctl);


                                // 根据移动方向，将按钮加到指定的位置.
                                // 注意参数的顺序， 先列后行!
                                switch (direction)
                                {
                                    case MoveDirection.Left:
                                        // 左
                                        this.tlpMain.Controls.Add(ctl, step.J - 1, step.I);
                                        break;
                                    case MoveDirection.Up:
                                        // 上
                                        this.tlpMain.Controls.Add(ctl, step.J, step.I - 1);
                                        break;
                                    case MoveDirection.Right:
                                        // 右
                                        this.tlpMain.Controls.Add(ctl, step.J + 1, step.I);
                                        break;
                                    case MoveDirection.Down:
                                        // 下
                                        this.tlpMain.Controls.Add(ctl, step.J, step.I + 1);
                                        break;
                                }

                                this.Refresh();
                                Thread.Sleep(500);



                                if (puzzle8.IsFinish)
                                {
                                    // 停止计时！
                                    this.timer1.Stop();

                                    EndAuto();

                                    MessageBox.Show("完成拼图处理！");
                                }


                            }));


        }



        /// <summary>
        /// 开始自动处理.
        /// </summary>
        private void BeginAuto()
        {
            // 不允许按开始.
            btnNew.Enabled = false;

            // 不允许重复按自动.
            btnAutoProcess.Enabled = false;

            // 不允许按表格中按钮.
            this.tlpMain.Enabled = false;
        }


        /// <summary>
        /// 结束自动处理.
        /// </summary>
        private void EndAuto()
        {
            // 允许按开始.
            btnNew.Enabled = true;

            // 允许重复按自动.
            // btnAutoProcess.Enabled = true;

            // 允许按表格中按钮.
            this.tlpMain.Enabled = true;
        }




        /// <summary>
        /// 计时器处理事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblTime.Text = (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");
        }

    }
}
