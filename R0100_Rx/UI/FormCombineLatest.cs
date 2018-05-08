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
    public partial class FormCombineLatest : Form
    {
        public FormCombineLatest()
        {
            InitializeComponent();
        }

        private void FormCombineLatest_Load(object sender, EventArgs e)
        {
            // 获取可观测对象.
            var aEventStream = this.btnA.FromClickEventPattern().Select(_ => "最新行情@" + DateTime.Now.ToString("HH:mm:ss"));
            var bEventStream = this.btnB.FromClickEventPattern().Select(_ => "最新持仓@" + DateTime.Now.ToString("HH:mm:ss"));


            // 两个可观测对象. 使用 CombineLatest 进行合并.
            var allEventStream = aEventStream.CombineLatest(bEventStream, DoMyWork);

            allEventStream
                .Subscribe(x => lblResult.Text = x.ToString());
        }


        private string DoMyWork(string x, string y)
        {
            return "当前资产 = " + x + "*" + y;
        }


    }
}
