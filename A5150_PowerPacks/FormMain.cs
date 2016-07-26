using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Microsoft.VisualBasic.PowerPacks;


namespace A5150_PowerPacks
{
    public partial class FormMain : Form
    {


        /// <summary>
        /// 画图的容器.
        /// </summary>
        private ShapeContainer canvas = new ShapeContainer();



        public FormMain()
        {
            InitializeComponent();


            // 初始化 画图的容器.
            InitShapeContainer();
        }



        /// <summary>
        /// 初始化 画图的容器.
        /// </summary>
        private void InitShapeContainer()
        {

            // 好像某些属性设置后， 没有效果.
            canvas.Location = new System.Drawing.Point(25, 25);
            canvas.Margin = new System.Windows.Forms.Padding(5);
            canvas.Name = "canvas";
            canvas.Size = new System.Drawing.Size(this.Width - 50, this.Height -50);
            canvas.TabStop = false;
                       
            // 边框.
            canvas.BorderStyle = BorderStyle.FixedSingle;
            // 背景色.
            canvas.BackColor = Color.LightYellow;


            // 容器加入窗口中.
            this.Controls.Add(canvas);
        }




        /// <summary>
        /// 画线.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 初始化一根线.
            LineShape line1 = new LineShape();

            // 线画在哪一个容器里面.
            line1.Parent = canvas;


            // 线坐标.
            line1.StartPoint = new System.Drawing.Point(200, 100);
            line1.EndPoint = new System.Drawing.Point(250, 300);
        }


        /// <summary>
        /// 画圆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OvalShape oval1 = new OvalShape();

            oval1.Parent = canvas;

            // Set the location and size of the circle.
            oval1.Left = 100;
            oval1.Top = 100;
            oval1.Width = 100;
            oval1.Height = 100;

        }



        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RectangleShape rect1 = new RectangleShape();

            rect1.Parent = canvas;
            // Set the location and size of the rectangle.
            rect1.Left = 250;
            rect1.Top = 150;
            rect1.Width = 300;
            rect1.Height = 100;

        }




        /// <summary>
        /// 画圆 填充
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fillOvalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OvalShape oval1 = new OvalShape();

            oval1.Parent = canvas;

            // Set the location and size of the circle.
            oval1.Left = 200;
            oval1.Top = 200;
            oval1.Width = 200;
            oval1.Height = 200;


            // 填充色.
            oval1.FillColor = Color.Red;
            // 渐变色.
            oval1.FillGradientColor = Color.Orange;
            // 渐变样式.
            oval1.FillGradientStyle = FillGradientStyle.Central;
            // 填充图案.
            oval1.FillStyle = FillStyle.Solid;

        }



    }
}
