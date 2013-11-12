using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using EdmxService.Model;
using EdmxService.ServiceImpl;


namespace EdmxService.App
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 浏览文件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // 弹出对话框选择文件.
            DialogResult diaResult = this.openFileDialog1.ShowDialog();

            if (diaResult == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFileName.Text = openFileDialog1.FileName;
            }

        }



        /// <summary>
        /// 开始处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.txtFileName.Text))
            {
                MessageBox.Show("Edmx 文件不存在！");
            }


            OracleDatabaseInfoReader reader = new OracleDatabaseInfoReader();

            // 读取表信息.
            List<TableOrViewInfo> tableList = reader.ReadAllTableAndViewInfo(this.txtConnString.Text);


            if (tableList == null || tableList.Count == 0)
            {
                MessageBox.Show("未能读取到 任何的表 / 列 信息！");
            }


            // 更新数据.
            DefaultEdmxCommentWriter writer = new DefaultEdmxCommentWriter();
            writer.EdmxCommentWriter(this.txtFileName.Text, tableList);


            MessageBox.Show("处理完毕！！！");
        }




    }
}
