using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.Reactive.Concurrency;

using R0100_Rx.Service;

namespace R0100_Rx.UI
{
    public partial class FormAmb : Form
    {
        public FormAmb()
        {
            InitializeComponent();
        }

        private void FormAmb_Load(object sender, EventArgs e)
        {
            // 获取可观测对象.
            var aEventStream = this.btnA.FromClickEventPattern().Select(_ => "用户A正在通话@" + DateTime.Now.ToString("HH:mm:ss"));
            var bEventStream = this.btnB.FromClickEventPattern().Select(_ => "用户B正在通话@" + DateTime.Now.ToString("HH:mm:ss"));


            // 两个可观测对象. 使用 Amb 进行合并.
            var allEventStream = aEventStream.Amb(bEventStream);

            allEventStream
                .Scan("", DoMyWork)
                .Subscribe(x => lblResult.Text = x.ToString());

        }


        private string DoMyWork(string x, string y)
        {
            return "通信线路独占使用中... " +  y;
        }



    }
}
