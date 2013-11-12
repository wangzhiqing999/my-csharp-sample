using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A0412_ChinesePinyin
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 清除全部输入.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtBaseText.Text = String.Empty;
            this.txtReplace.Text = String.Empty;
            this.txtResult.Text = String.Empty;
        }

        /// <summary>
        /// 向下复制.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyFromBaseToReplace_Click(object sender, EventArgs e)
        {
            this.txtReplace.Text = this.txtBaseText.Text;
        }


        /// <summary>
        /// 向上复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyFromReplaceToBase_Click(object sender, EventArgs e)
        {
            this.txtBaseText.Text = this.txtReplace.Text;
        }


        /// <summary>
        /// 生成文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtBaseText.Text.Length != txtReplace.Text.Length)
            {
                MessageBox.Show("源文本与替换文本的长度要一致", "注意");
                return;
            }

            MyChineseConvert convert = new MyChineseConvert();
            List<string> resultList = convert.PinyingConvert(txtBaseText.Text, txtReplace.Text);


            // 先清空结果区域.
            this.txtResult.Text = String.Empty;

            // 依次填写结果数据 （如果有多个的话， 自动换行）.
            foreach (String oneResult in resultList)
            {
                this.txtResult.AppendText(oneResult);
                this.txtResult.AppendText("\r\n");
            }
        }




    }
}
