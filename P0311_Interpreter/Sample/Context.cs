using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.Sample
{

    /// <summary>
    /// 包含解释器之外的一些全局信息
    /// </summary>
    class Context
    {
        private string input;
        public string Input
        {
            get { return input; }
            set { input = value; }
        }


        private string output;
        public string Output
        {
            get { return output; }
            set { output = value; }
        }

    }

}
