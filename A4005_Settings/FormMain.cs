using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;


namespace A4005_Settings
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 取得连接字符串的 ProviderName.
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        private static string GetProviderName(string connectionName)
        {
            // 强制重新载入配置文件的ConnectionStrings配置节
            ConfigurationManager.RefreshSection("ConnectionStrings");

            string providerName = ConfigurationManager.ConnectionStrings[connectionName].ProviderName;
            return providerName;
        } 




        /// <summary>
        /// 测试读取.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestRead_Click(object sender, EventArgs e)
        {

            Properties.Settings config = Properties.Settings.Default;


            this.txtResult.Text = String.Empty;

            this.txtResult.AppendText("测试的 TestPath 属性 = ");
            this.txtResult.AppendText(config.TestPath );
            this.txtResult.AppendText("\r\n");

            this.txtResult.AppendText("测试的 TestConnString 属性 = ");
            this.txtResult.AppendText(config.TestConnString);
            this.txtResult.AppendText("\r\n");



            string providerName = GetProviderName("A4005_Settings.Properties.Settings.TestConnString");

            this.txtResult.AppendText("测试的 TestConnString providerName = ");
            this.txtResult.AppendText(providerName);
            this.txtResult.AppendText("\r\n");



        }




        private void btnTestWrite_Click(object sender, EventArgs e)
        {
            FormConfig configForm = new FormConfig();
                       
            configForm.LoadConfig();

            configForm.ShowDialog(this);
        }




    }
}
