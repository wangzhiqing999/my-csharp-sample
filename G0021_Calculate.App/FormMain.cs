using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using G0021_Calculate.Service;


namespace G0021_Calculate.App
{
    public partial class FormMain : Form
    {

        /// <summary>
        /// 计算数据.
        /// </summary>
        private AddCalculateData calculateData = new AddCalculateData();

        /// <summary>
        /// 4个按钮.
        /// </summary>
        private Button[] buttonArray = new Button[4];


        /// <summary>
        /// 累计回答正确次数.
        /// </summary>
        private int successCount = 0;


        /// <summary>
        /// 构造函数.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();


            buttonArray[0] = this.btnA;
            buttonArray[1] = this.btnB;
            buttonArray[2] = this.btnC;
            buttonArray[3] = this.btnD;

            // 按钮事件绑定.
            for (int i = 0; i < this.buttonArray.Length; i++)
            {
                // 设置按钮结果.
                this.buttonArray[i].Click += new EventHandler(btnAnswer_Click);
            }
        }


        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            // 开始一个新计算.
            NewCalculate();

            // 启动定时器.
            this.timerMain.Start();

        }


        /// <summary>
        /// 定时器的处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerMain_Tick(object sender, EventArgs e)
        {
            // 取得当前秒数.
            // 转换为 int 类型
            int currentTime = Convert.ToInt32(this.lblTime.Text);

            // 时间递减.
            currentTime--;
            
            // 设置结果.
            this.lblTime.Text = currentTime.ToString();


            // 超时， 重新计算.
            if (currentTime <= 0)
            {
                NewCalculate();
            }
        }


        /// <summary>
        /// 回答按钮的点击.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void  btnAnswer_Click(object sender, EventArgs e)
        {
            Button thisBtn = sender as Button;
            if (Convert.ToInt32(thisBtn.Text) == this.calculateData.ResultValue)
            {
                // 选择正确.
                successCount++;
                lblResult.Text = String.Format("您累计回答正确次数：{0}", successCount);

                // 计算下一题
                NewCalculate();
            }
            else
            {
                // 结束计时器处理.
                this.timerMain.Stop();
                // 选择错误.
                MessageBox.Show("回答错误！");
            }
        }





        /// <summary>
        /// 一次新的计算.
        /// </summary>
        public void NewCalculate()
        {
            // 数据准备.
            calculateData.DoPrepare();

            // 填写题目.
            this.lblCalclateInfo.Text = calculateData.CalculateInfo;

            // 设置结果列表.
            List<int> answerList = new List<int>();

            // 加入正确结果.
            answerList.Add(calculateData.ResultValue);

            // 加入3个错误的结果.
            answerList.AddRange(calculateData.WrongDataList.Take(this.buttonArray.Length - 1));

            // 结果列表随机排序.
            var query =
                from data in answerList
                orderby Guid.NewGuid()
                select data;

            answerList = query.ToList();
                
            // 设置画面按钮.

            for (int i = 0; i < this.buttonArray.Length; i++)
            {
                // 设置按钮结果.
                this.buttonArray[i].Text = answerList[i].ToString();
            }


            // 重置计算时间.
            this.lblTime.Text = "10";
        }







    }
}
