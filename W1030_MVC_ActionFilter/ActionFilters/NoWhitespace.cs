using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W1030_MVC_ActionFilter.ActionFilters
{


    /// <summary>
    /// 不启用去除空格特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class NoWhitespace : Attribute
    {
        public NoWhitespace()
        {
            // 本类没有任何代码，仅仅是一个占位的标识
        }
    }


}