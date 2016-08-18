using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;


namespace WPF_0080_RoutedEvent
{


    /// <summary>
    /// 用于承载时间消息的事件参数.
    /// </summary>
    public class ReportTimeEventArgs : RoutedEventArgs
    {

        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source) { }



        public DateTime ClickTime { set; get; }


    }

}
