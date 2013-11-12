using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0012_OO_AutoProp.Sample
{

    /// <summary>
    /// 当属性访问器中不需要其他逻辑时，自动实现的属性可使属性声明变得更加简洁。
    /// 当您如下面的示例所示声明属性时，编译器将创建一个私有的匿名后备字段，
    /// 该字段只能通过属性的 get 和 set 访问器进行访问。 
    /// 
    /// 
    /// 请注意，本类 没有定义任何的 内部变量来存储 属性值。
    /// 内部变量由编译器创建。
    /// 
    /// </summary>
    class Apple
    {
        public String Country { get; set; }
        public String Color { get; set; }


        // private set;  表明该字段 对外是 只读的
        public bool Isgood { get; private set; }


        public override string ToString()
        {
            if (Color == "红")
            {
                Isgood = true;
            }

            return Country + "产" + Color + "色" +  (Isgood?"好":"不好") + "苹果";
        }
    }

}
