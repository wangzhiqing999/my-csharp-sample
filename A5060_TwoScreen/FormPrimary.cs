using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A5060_TwoScreen
{
    public partial class FormPrimary : Form
    {
        public FormPrimary()
        {
            InitializeComponent();
        }




        private void FormPrimary_Load(object sender, EventArgs e)
        {
            StringBuilder buff = new StringBuilder();
            buff.AppendFormat("显示器个数:{0}", Screen.AllScreens.Count());
            buff.AppendLine();

            foreach (Screen sc in Screen.AllScreens)
            {
                buff.AppendFormat("设备名称:{0}; 是否是主设备:{1}; 工作区域:{2} ",
                    sc.DeviceName, sc.Primary, sc.WorkingArea);
                buff.AppendLine();
            }

            this.lblBasicInfo.Text = buff.ToString();



            if (Screen.AllScreens.Count() == 1)
            {
                // 只有一个显示器.
                // 子窗口不显示了.
                return;
            }

            
            // 设置本窗口占据  主显示器.
            this.Top = Screen.PrimaryScreen.WorkingArea.Top;
            this.Left = Screen.PrimaryScreen.WorkingArea.Left;
            // 最大化.
            this.WindowState = FormWindowState.Maximized;



            // 初始化子窗口.
            FormSub formSub = new FormSub();
            // 第二屏幕.
            Screen subScreen = null;
            foreach (Screen sc in Screen.AllScreens)
            {
                if (!sc.Primary)
                {
                    subScreen = sc;
                    break;
                }                
            }


            // 设置子窗口占据  第二显示器.
            formSub.Top = subScreen.WorkingArea.Top;
            formSub.Left = subScreen.WorkingArea.Left;
            // 最大化.
            formSub.WindowState = FormWindowState.Maximized;
            formSub.Show();

        }



    }
}
