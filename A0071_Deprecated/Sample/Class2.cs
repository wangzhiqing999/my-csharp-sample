using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0071_Deprecated.Sample
{


    
    public class Class2
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
