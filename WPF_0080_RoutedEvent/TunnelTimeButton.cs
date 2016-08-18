using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Controls;



namespace WPF_0080_RoutedEvent
{
    public class TunnelTimeButton : Button
    {

        // 声明和注册路由事件.
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent(
            "TunnelReportTime", RoutingStrategy.Tunnel, typeof(EventHandler<ReportTimeEventArgs>), typeof(TunnelTimeButton)
            );



        // CLR 事件包装器.
        public event RoutedEventHandler TunnelReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }


        // 激发路由事件， 借用 Click 事件触发.
        protected override void OnClick()
        {
            base.OnClick();

            ReportTimeEventArgs args = new ReportTimeEventArgs(ReportTimeEvent, this);
            args.ClickTime = DateTime.Now;
            this.RaiseEvent(args);
        }
         

    }
}
