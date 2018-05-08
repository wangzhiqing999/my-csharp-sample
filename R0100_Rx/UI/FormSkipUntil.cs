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
    public partial class FormSkipUntil : Form
    {
        public FormSkipUntil()
        {
            InitializeComponent();
        }

        private void FormSkipUntil_Load(object sender, EventArgs e)
        {
            // 获取可观测对象.
            var aEventStream = this.btnTest.FromClickEventPattern().Select(_ => "触发事件@" + DateTime.Now.ToString("HH:mm:ss"));

            // 获取可观测对象.
            var bEventStream = this.btnStart.FromClickEventPattern();


            aEventStream
                // SkipUntil , 也就是一旦 bEventStream 触发了， 就开始处理了.  未开始之前，都是忽略的。
                .SkipUntil(bEventStream)
                .Subscribe(x => lblResult.Text = x.ToString());
        }
    }
}
