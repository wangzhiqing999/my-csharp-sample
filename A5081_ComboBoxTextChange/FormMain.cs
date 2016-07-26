using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5081_ComboBoxTextChange
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 数据源.
        /// </summary>
        private List<TestData> mainDataList = TestData.GetDemoTestDataList();



        private void FormMain_Load(object sender, EventArgs e)
        {

            // Combox 数据源绑定.
            this.comboBox1.DataSource = mainDataList;

            // 获取的数值.
            this.comboBox1.ValueMember = "Code";
            // 显示是  缩写.
            this.comboBox1.DisplayMember = "DisplayName";


            // 自行绘制.
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;

            // 绘制的方法.
            this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox1_DrawItem);
        }



        private void ComboBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                // 避免设计环境下出错.
                return;
            }
            // 绘制背景
            e.DrawBackground();
            // 文字颜色.
            Brush myBrush = Brushes.Black;


            // 取得当前选择行数据.
            TestData data = mainDataList[e.Index];


            // 下拉列表中， 显示的是 全称.
            e.Graphics.DrawString(data.Name,
                e.Font, myBrush, e.Bounds.Left, e.Bounds.Top, StringFormat.GenericDefault);
        }



    }
}
