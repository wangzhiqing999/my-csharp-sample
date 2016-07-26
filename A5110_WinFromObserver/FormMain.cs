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

    public partial class FormMain : Form, IObserver
    {

        /// <summary>
        /// 具体主题（ConcreteSubject）角色.
        /// </summary>
        private ItemManager itemManager;


        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            // 初始化管理器.
            InitItemManageer();
        }


        /// <summary>
        /// 初始化 具体主题
        /// </summary>
        private void InitItemManageer()
        {
            itemManager = new ItemManager();
            // 初始化数据.
            itemManager.SelectedItemList = new List<int>();

            // 当前窗口，会修改数据， 同时也是观察者.
            itemManager.Attach(this);


            // 添加 奇数的子窗口.
            FormSubOdd frmSubOdd = new FormSubOdd()
            {
                ItemManager = itemManager,
                Left = 10,
                Top = 10,
            };
            itemManager.Attach(frmSubOdd);


            // 添加 偶数的子窗口.
            FormSubEven frmSubEven = new FormSubEven()
            {
                ItemManager = itemManager,
                Left = 10,
                Top = 350,
            };
            itemManager.Attach(frmSubEven);


            frmSubOdd.Show();
            frmSubEven.Show();


            // 初始化完毕后， 先尝试通知一次.
            itemManager.Notify();
        }


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
            itemManager.SelectedItemList.Add( Convert.ToInt32( text));

            // 数据修改完毕后， 通知所有的 观察者， 根据需要， 修改自己的画面.
            itemManager.Notify();
        }





        #region IObserver 成员


        /// <summary>
        /// 观察者处理的逻辑.
        /// </summary>
        public void GoUpdate()
        {
            this.tableLayoutPanel1.Controls.Clear();

            // 初始化本表格的按钮.
            for (int i = 1; i < 10; i++)
            {
                if( itemManager.SelectedItemList.Contains(i)) {
                    // 对于已经选择的数据， 不显示在主画面中.
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
        }

        #endregion
    }


}
