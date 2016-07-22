using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0056_Covariant.Sample
{

    /// <summary>
    /// 用于测试的 父类.
    /// </summary>
    public class TestParent
    {
        public string Name { set; get; }

        public virtual void PrintMe()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return String.Format("TestParent {0}", this.Name);
        }
    }


    /// <summary>
    /// 用于测试的 子类.
    /// </summary>
    public class TestSub : TestParent
    {
        public override string ToString()
        {
            return String.Format("TestSub {0}", this.Name);
        }
    }


}
