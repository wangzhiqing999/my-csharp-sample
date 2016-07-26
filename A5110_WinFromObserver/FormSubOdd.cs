using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



using A5110_WinFromObserver.Sample;


namespace A5110_WinFromObserver
{

    /// <summary>
    /// 观察者窗口.
    /// </summary>
    public partial class FormSubOdd : Form, IObserver
    {
        public FormSubOdd()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 具体主题（ConcreteSubject）角色.
        /// </summary>
        public ItemManager ItemManager { set; get; }





        #region IObserver 成员


        /// <summary>
        /// 观察者处理的逻辑.
        /// </summary>
        public void GoUpdate()
        {
            this.tableLayoutPanel1.Controls.Clear();

            // 初始化本表格的按钮.
            foreach (int i in ItemManager.SelectedItemList)
            {
                if (i % 2 == 0)
                {
                    // 本画面仅仅显示奇数.
                    continue;
                }

                Button btnItem = new Button();
                this.tableLayoutPanel1.Controls.Add(btnItem);
                btnItem.Dock = System.Windows.Forms.DockStyle.Fill;
                btnItem.Location = new System.Drawing.Point(3, 3);
                btnItem.Name = "button" + i;
                btnItem.Size = new System.Drawing.Size(119, 68);
                btnItem.TabIndex = 0;
                btnItem.Text = i.ToString();
                btnItem.UseVisualStyleBackColor = true;
                btnItem.Click += new System.EventHandler(this.btnItem_Click);
            }


            if (!this.Visible)
            {
                // 如果窗口隐藏了， 那么显示.
                this.Show();
            }
        }

        #endregion


        /// <summary>
        /// 当前表格中数据的点击.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItem_Click(object sender, EventArgs e)
        {
            // 取得 当前点的按钮.
            Button btn = sender as Button;
            // 取得 当前点的按钮的文字.
            string text = btn.Text;

            // 将选择的内容， 提交给管理器进行管理.
            ItemManager.SelectedItemList.Remove(Convert.ToInt32(text));

            // 数据修改完毕后， 通知所有的 观察者， 根据需要， 修改自己的画面.
            ItemManager.Notify();
        }



        /// <summary>
        /// 子窗口 手动关闭的情况下， 隐藏掉.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSubOdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }


    }
}
