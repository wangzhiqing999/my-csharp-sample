using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.ServiceProcess;


using System.Diagnostics;


namespace WS010_AdminAble.UI
{
    public partial class FormAdmin : Form
    {
        // 参考网站：
        // http://www.cr173.com/html/15350_1.html


        public FormAdmin()
        {
            InitializeComponent();
        }




        /// <summary>
        /// Windows 服务中。
        /// ProjectInstaller.cs 中的那个 serviceInstaller1 属性里面的 ServiceName
        /// 
        /// 
        /// 注意：那个 DisplayName 是显示在 管理工具--〉服务  里面的名称。 不一定是实际的 ServiceName
        /// 仅仅当 DisplayName 没有设置的情况下，  管理工具--〉服务  里面, 才会显示  ServiceName
        /// </summary>
        private const string SERVICE_NAME = "测试 Windows Service";


        /// <summary>
        /// 安装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstall_Click(object sender, EventArgs e)
        {
            string CurrentDirectory = System.Environment.CurrentDirectory;
            System.Environment.CurrentDirectory = CurrentDirectory + "\\Service";
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "InstallService.bat";
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            System.Environment.CurrentDirectory = CurrentDirectory;

            MessageBox.Show("安装完成！");
        }


        /// <summary>
        /// 卸载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnstall_Click(object sender, EventArgs e)
        {
            string CurrentDirectory = System.Environment.CurrentDirectory;
            System.Environment.CurrentDirectory = CurrentDirectory + "\\Service";
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "UnInstallService.bat";
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            System.Environment.CurrentDirectory = CurrentDirectory;

            MessageBox.Show("卸载完成！");
        }



        /// <summary>
        /// 启动服务.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {

                ServiceController serviceController = new ServiceController(SERVICE_NAME);
                serviceController.Start();

                MessageBox.Show("启动服务完成！");
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("发生异常，服务可能还没有安装！");
            } 
        }


        /// <summary>
        /// 停止服务.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController serviceController = new ServiceController(SERVICE_NAME);
                if (serviceController.CanStop)
                {
                    serviceController.Stop();

                    MessageBox.Show("停止服务完成！");
                }
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("发生异常，服务可能还没有安装！");
            } 
        }



        /// <summary>
        /// 服务状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStatus_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController serviceController = new ServiceController(SERVICE_NAME);
                string Status = serviceController.Status.ToString();

                MessageBox.Show(Status);
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("发生异常，服务可能还没有安装！");
            }

        }





        
    }

}
