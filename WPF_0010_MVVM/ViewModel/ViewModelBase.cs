using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel
{


    /// <summary>
    /// Model-View-ViewModel  体系中，  ViewModel 的基类.
    /// 
    /// 
    /// INotifyPropertyChanged的接口: 任何实现了这个接口的类，当属性发生改变的时候会通知所有监听者.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {








        #region INotifyPropertyChanged 成员


        public event PropertyChangedEventHandler PropertyChanged;


        #endregion






        #region INotifyPropertyChanged 方法


        /// <summary>
        /// 当属性改变的时候，调用该方法来发起一个消息，通知View中绑定了propertyName的元素做出调整.
        /// </summary>
        /// <param name="propertyName"></param>
        public void RaisePropertyChanged(string propertyName)
        {

            // 得到一个副本以预防线程问题.
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion


    }
}
