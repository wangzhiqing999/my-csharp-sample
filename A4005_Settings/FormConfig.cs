using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.Configuration;
using System.Diagnostics;

using A4005_Settings.Util;


namespace A4005_Settings
{
    public partial class FormConfig : Form
    {

        


        public FormConfig()
        {
            InitializeComponent();
        }




        /// <summary>
        /// 加载配置信息.
        /// </summary>
        public void LoadConfig()
        {
            Properties.Settings config = Properties.Settings.Default;
            this.txtPath.Text = config.TestPath;



            string providerName = ConfigurationManager.ConnectionStrings["A4005_Settings.Properties.Settings.TestConnString"].ProviderName;
            this.cboDatabase.Text = providerName;




            string [] connKeyValueArray = config.TestConnString.Split(';');

            foreach (string keyValStr in connKeyValueArray)
            {
                string[] keyValue = keyValStr.Split('=');

                if (keyValue.Length == 2)
                {
                    switch (keyValue[0].ToUpper())
                    {
                        case "DATA SOURCE":
                            this.txtDataSource.Text = keyValue[1];
                            break;

                        case "PORT":
                            this.txtPort.Text = keyValue[1];
                            break;

                        case "INITIAL CATALOG":
                            this.txtInitialCatalog.Text = keyValue[1];
                            break;

                        case "USER ID":
                            this.txtUserId.Text = keyValue[1];
                            break;

                        case "PASSWORD":
                            this.txtPassword.Text = keyValue[1];
                            break;
                    }
                }
            }

        }



        /// <summary>
        /// 取得连接字符串.
        /// </summary>
        /// <returns></returns>
        private string GetConnString()
        {
            StringBuilder buff = new StringBuilder();

            buff.AppendFormat("Data Source={0};", this.txtDataSource.Text);


            if (!String.IsNullOrEmpty(this.txtPort.Text))
            {
                // 如果指定了端口.
                buff.AppendFormat("port={0};", this.txtPort.Text);
            }

            if (!String.IsNullOrEmpty(this.txtInitialCatalog.Text))
            {
                // 如果指定了初始的数据库.
                buff.AppendFormat("Initial Catalog={0};", this.txtInitialCatalog.Text);
            }


            buff.AppendFormat("User Id={0};Password={1}", this.txtUserId.Text, this.txtPassword.Text);

            return buff.ToString();
        }




        /// <summary>
        /// 测试连接.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestConn_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;


            AbstractConnTest connTest = null;

            string connString = GetConnString();


            switch (this.cboDatabase.Text)
            {
                case "System.Data.OracleClient":
                    // 测试 Oracle.

                    connTest = new OracleConnTest();

                    

                    break;


                case "System.Data.SqlClient":
                    // 测试 SQL Server.

                    connTest = new SqlConnTest();
                    break;


                case "MySql.Data.MySqlClient":
                    // 测试 Mysql.

                    connTest = new MySqlConnTest();
                    break;

            }



            if (connTest == null)
            {
                MessageBox.Show("请先选择数据库类型!!!");
            }
            else
            {


                bool testResult = connTest.TestConnect(connString);

                if (testResult)
                {
                    MessageBox.Show("测试通过！");
                }
                else
                {
                    MessageBox.Show("测试失败！\r\n" + connTest.ResultMessage);
                }
            }

            this.Cursor = Cursors.Default;
        }



        /// <summary>
        /// 保存.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 配置文件名.
            string appConfigFileName = System.Windows.Forms.Application.ExecutablePath + ".config";

            // 加载配置文件.
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(appConfigFileName);

            XmlNode xNode;
            XmlElement xElement;

            // 取到 配置的节点.
            xNode = xDoc.SelectSingleNode("//applicationSettings//A4005_Settings.Properties.Settings");

            // 修改一个属性的数据.
            xElement = (XmlElement)xNode.SelectSingleNode("//setting[@name='TestPath']//value");
            xElement.InnerText = txtPath.Text;
           





            // 连接字符串需要去另外一个节点去修改.

            // 取到 配置的节点.
            xNode = xDoc.SelectSingleNode("//connectionStrings");

            // 取得指定的连接字符串节点.
            xElement = (XmlElement)xNode.SelectSingleNode("//add[@name='A4005_Settings.Properties.Settings.TestConnString']");

            // 修改 providerName.
            xElement.SetAttribute("providerName", this.cboDatabase.Text);

            // 修改 connectionString
            xElement.SetAttribute("connectionString", this.GetConnString());


            // 物理保存.
            xDoc.Save(appConfigFileName);




            

            this.Close();


            // 因为 修改了 app.config. 要重新启动当前 exe 程序， 来重新加载配置文件.
            Restart();


            // 重新启动了， 自然就关闭当前的了.
            this.Owner.Close();




        }



        private void Restart()
        {
            Process process = new Process();

            // exe 的目录.
            process.StartInfo.FileName = System.Windows.Forms.Application.ExecutablePath;

            // 运行.
            process.Start();
        }


    }
}
