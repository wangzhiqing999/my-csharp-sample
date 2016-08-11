using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using G0091_LianLianKan.Service;


namespace G0091_LianLianKan.WinForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }




        private LianLianKanService lianLianKan = new LianLianKanService();




        /// <summary>
        /// 画面初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {

            lianLianKan.Init(8, 10, 8);


            Console.WriteLine(lianLianKan.ToString());


            // 删除 表格中所有 已存在的按钮.
            this.tlpMain.Controls.Clear();



            for (int row = 0; row < lianLianKan.Row; row++)
            {
                for (int col = 0; col < lianLianKan.Col; col++)
                {
                    Button btnNumber = new Button()
                    {
                        // 填充方式.
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        Text = lianLianKan[row, col].ToString(),
                        UseVisualStyleBackColor = true,
                        BackColor = System.Drawing.SystemColors.Control
                    };

                    LianLianKanItem item = new LianLianKanItem()
                    {
                        Row = row,
                        Col = col,
                    };
                    btnNumber.Tag = item;


                    // 按钮点击.
                    btnNumber.Click += new System.EventHandler(this.btnNumber_Click);

                    // 按钮加入 Table.
                    // 注意参数的顺序：  先列 后行.
                    this.tlpMain.Controls.Add(btnNumber, col, row);
                }
            }

        }




        /// <summary>
        /// 第一个按钮  与  第二个按钮.
        /// </summary>
        private Button btnFirst, btnSecond;



        /// <summary>
        /// 按钮事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btnFirst == null)
            {
                // 第一次按.
                btnFirst = btn;

                btn.BackColor = System.Drawing.SystemColors.ActiveCaption;

                return;
            }


            // 第二次按.
            if (btnFirst == btn)
            {
                // 取消动作.
                btnFirst = null;
                btn.BackColor = System.Drawing.SystemColors.Control;

                return;
            }


            // 第二次按 不是取消操作.
            btnSecond = btn;


            LianLianKanItem item1 = btnFirst.Tag as LianLianKanItem;
            LianLianKanItem item2 = btnSecond.Tag as LianLianKanItem;


            if (lianLianKan.TryLianLian(item1, item2))
            {
                // 成功了.
                // 删除按钮.
                this.tlpMain.Controls.Remove(btnFirst);
                this.tlpMain.Controls.Remove(btnSecond);


                // 重新开始下一轮.
                btnFirst = null;
                btnSecond = null;
            }
            else
            {
                // 失败了. 清除输入信息.

                btnFirst.BackColor = System.Drawing.SystemColors.Control;
                btnSecond.BackColor = System.Drawing.SystemColors.Control;

                btnFirst = null;
                btnSecond = null;
            }

        }


    }
}
