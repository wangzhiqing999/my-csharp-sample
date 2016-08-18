using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_0070_Binding.Service
{
    class Calculator
    {

        public string Add(string arg1, string arg2)
        {
            double x = 0;
            double y = 0;
            double z = 0;

            if (double.TryParse(arg1, out x) && double.TryParse(arg2, out y))
            {
                z = x + y;
                return z.ToString();
            }
            return "数据输入错误！";
        }

    }
}
