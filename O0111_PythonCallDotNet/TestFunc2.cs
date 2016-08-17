using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O0111_PythonCallDotNet
{

    public class TestFunc2
    {

        private int aaa = 11;


        /// <summary>
        /// 属性.
        /// </summary>
        public int AAA
        {
            get { return aaa; }
            set { aaa = value; }
        }


        /// <summary>
        /// 非静态方法.
        /// </summary>
        public void ShowAAA()
        {
            Console.WriteLine("AAA is {0}", this.aaa);
        }



    }
}
