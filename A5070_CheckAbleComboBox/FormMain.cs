using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5070_CheckAbleComboBox
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            List<string> dataList = new List<string>();
            dataList.Add("北京");
            dataList.Add("上海");
            dataList.Add("广州");
            dataList.Add("深圳");
            dataList.Add("重庆");

            this.cboTest.CheckAbleItemList = dataList;

        }


        /// <summary>
        /// 获取输入结果.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetResult_Click(object sender, EventArgs e)
        {
            this.txtResult.Text = String.Empty;

            foreach (string result in this.cboTest.CheckedItemList)
            {
                this.txtResult.AppendText(result + "\r\n");
            }
        }



    }
}
