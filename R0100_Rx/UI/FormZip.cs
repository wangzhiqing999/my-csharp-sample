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
    public partial class FormZip : Form
    {
        public FormZip()
        {
            InitializeComponent();
        }

        private void FormZip_Load(object sender, EventArgs e)
        {
            // 获取可观测对象.
            var aEventStream = this.btnA.FromClickEventPattern().Select(_ => "零件A@" + DateTime.Now.ToString("HH:mm:ss"));
            var bEventStream = this.btnB.FromClickEventPattern().Select(_ => "零件B@" + DateTime.Now.ToString("HH:mm:ss"));

            // 两个可观测对象. 使用 Zip 进行合并.
            var allEventStream = aEventStream.Zip(bEventStream, DoMyWork);

            allEventStream
                .Subscribe(x => lblResult.Text = x.ToString());
        }


        private string DoMyWork(string x, string y)
        {
            return "产品 = 【" + x + " + " + y + "】";
        }

    }
}
