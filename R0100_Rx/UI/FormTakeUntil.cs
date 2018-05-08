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
    public partial class FormTakeUntil : Form
    {
        public FormTakeUntil()
        {
            InitializeComponent();
        }

        private void FormTakeUntil_Load(object sender, EventArgs e)
        {
            // 获取可观测对象.
            var aEventStream = this.btnTest.FromClickEventPattern().Select(_ => "触发事件@" + DateTime.Now.ToString("HH:mm:ss"));

            // 获取可观测对象.
            var bEventStream = this.btnStop.FromClickEventPattern();


            aEventStream
                // TakeUntil , 也就是一旦 bEventStream 触发了， 就结束了.
                .TakeUntil(bEventStream)
                .Subscribe(x => lblResult.Text = x.ToString());

        }
    }
}
