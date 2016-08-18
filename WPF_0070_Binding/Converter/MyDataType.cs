using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_0070_Binding.Converter
{



    /// <summary>
    /// 种类.
    /// </summary>
    public enum Category
    {
        Bomber,
        Fighter
    }



    /// <summary>
    /// 状态.
    /// </summary>
    public enum State
    {
        Available,
        Locked,
        Unknown
    }



    public class Plane
    {
        public Category Category { set; get; }

        public string Name { set; get; }


        public State State { set; get; }

    }


}
