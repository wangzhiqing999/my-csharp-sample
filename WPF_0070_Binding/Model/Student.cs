using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WPF_0070_Binding.Model
{

    /// <summary>
    /// 用于数据绑定的 Model 类.
    /// </summary>
    public class Student : INotifyPropertyChanged
    {

        /// <summary>
        /// INotifyPropertyChanged 成员
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// 内部变量.
        /// </summary>
        private string name;


        /// <summary>
        /// 外部属性.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                // 设置内部变量的数据.
                name = value;
                // 触发事件. 告诉  数据已经发生变化了.
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
        


    }


}
