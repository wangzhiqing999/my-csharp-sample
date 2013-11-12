using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0071_Deprecated.Sample
{

    [Obsolete("这个类不推荐使用，请使用 Class2 来代替之.")]
    public class Class1
    {

        [Obsolete("这个方法不推荐使用，请使用 Method2 来代替之.")]
        public void Method1()
        {
        }

        public void Method2()
        {
        }

    }
}
