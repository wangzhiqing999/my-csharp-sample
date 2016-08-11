using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using G0101_Maze.Service;

namespace G0101_Maze.WinForm
{
    public partial class FormMaze : Form
    {


        /// <summary>
        /// 迷宫后台.
        /// </summary>
        private Maze maze;


        /// <summary>
        /// 迷宫图片.
        /// </summary>
        private PictureBox[,] picArray;


        public FormMaze()
        {
            InitializeComponent();

            // 默认初始化.
            maze = new Maze();

            // 事件绑定.
            maze.Moving += new MovingHandler(PlayerMoving);
        }



        /// <summary>
        /// 初始化迷宫.
        /// </summary>
        private void InitMaze()
        {
            this.tlpMain.Controls.Clear();

            // 迷宫列数.
            this.tlpMain.ColumnCount = maze.MazeColumns;
            this.tlpMain.ColumnStyles.Clear();
            for (int i = 0; i < this.tlpMain.ColumnCount; i++)
            {
                this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            }

            // 迷宫行数.
            this.tlpMain.RowCount = maze.MazeRows;
            this.tlpMain.RowStyles.Clear();
            for (int i = 0; i < this.tlpMain.RowCount; i++)
            {
                this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            }

            // 表格大小.
            this.tlpMain.Width = 64 * this.tlpMain.ColumnCount;
            this.tlpMain.Height = 64 * this.tlpMain.RowCount;


            // 初始化图片数组.
            picArray = new PictureBox[this.tlpMain.RowCount, this.tlpMain.ColumnCount];


            // 迷宫图片.
            for (int i = 0; i < this.tlpMain.RowCount; i++)
            {
                for (int j = 0; j < this.tlpMain.ColumnCount; j++)
                {
                    PictureBox pic = new PictureBox();
                    picArray[i, j] = pic;
                    this.tlpMain.Controls.Add(pic, j, i);

                    SetPicImage(i, j);
                    

                    pic.Location = new System.Drawing.Point(0, 0);
                    pic.Margin = new System.Windows.Forms.Padding(0);
                    pic.Size = new System.Drawing.Size(64, 64);
                    pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pic.TabStop = false;

                    
                }
            }
        }



        private void FormMaze_Load(object sender, EventArgs e)
        {
            // 初始化迷宫.
            InitMaze();
        }



        /// <summary>
        /// 开始.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            maze.Start();

            btnStart.Visible = false;
        }



        /// <summary>
        /// 设置图片.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void SetPicImage(int row, int col)
        {
            switch (maze[row, col])
            {
                case Maze.START_FLAG:
                    picArray[row, col].Image = this.imgLstMaze.Images["START"];
                    break;

                case Maze.FINISH_FLAG:
                    picArray[row, col].Image = this.imgLstMaze.Images["FINISH"];
                    break;

                case Maze.WALL_FLAG:
                    picArray[row, col].Image = this.imgLstMaze.Images["WALL"];
                    break;

                case 0:
                    picArray[row, col].Image = this.imgLstMaze.Images["BLANK"];
                    break;

                default:
                    picArray[row, col].Image = this.imgLstMaze.Images["USER"];
                    break;
            }
        }


        /// <summary>
        /// 数字单元移动.
        /// </summary>
        /// <param name="step"></param>
        /// <param name="direction"></param>
        private void PlayerMoving(MoveStep step, MoveDirection direction)
        {
            // 恢复 原始位置图片。
            SetPicImage(step.Row, step.Column);

            // 设置 目标位置图片.
            switch (direction)
            {
                case MoveDirection.Up:
                    SetPicImage(step.Row - 1, step.Column);
                    break;

                case MoveDirection.Down:
                    SetPicImage(step.Row + 1, step.Column);
                    break;

                case MoveDirection.Left:
                    SetPicImage(step.Row, step.Column - 1);
                    break;

                case MoveDirection.Right:
                    SetPicImage(step.Row, step.Column + 1);
                    break;
            }

            if (maze.IsFinish)
            {
                MessageBox.Show("完成！");
            }
        }



        private void FormMaze_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control || e.Alt || e.Shift)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    maze.Up();
                    break;

                case Keys.Down:
                    maze.Down();
                    break;

                case Keys.Left:
                    maze.Left();
                    break;

                case Keys.Right:
                    maze.Rigth();
                    break;
            }
        }

        private void FormMaze_KeyUp(object sender, KeyEventArgs e)
        {

        }


    }
}
