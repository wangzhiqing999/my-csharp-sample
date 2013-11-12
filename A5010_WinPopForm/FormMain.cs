using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using A5010_WinPopForm.Sample;


namespace A5010_WinPopForm
{
    public partial class FormMain : Form
    {

        private PopForm tf;


        public FormMain()
        {
            InitializeComponent();

            tf = new PopForm(); 
        }



        private void btnTest_Click(object sender, EventArgs e)
        {
            tf.SetBackgroundBitmap(
                new Bitmap("Sample\\popup.jpg"),
                Color.FromArgb(255, 0, 255));

            tf.StopInterval = 10000;

            tf.Pop("弹出消息标题", "测试弹出的消息内容！", new CallBackDelegate(x)); 
        }



        private void x(string x)
        {
            MessageBox.Show("点击了" + x);
        } 

    }
}
