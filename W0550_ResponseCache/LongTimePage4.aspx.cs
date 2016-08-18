using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Threading;

namespace W0550_ResponseCache
{
    public partial class LongTimePage4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // 模拟长时间的数据读取/加载.
            Thread.Sleep(5000);




            Context.Response.Cache.SetCacheability(HttpCacheability.Public);
            Context.Response.Cache.SetMaxAge(new TimeSpan(0, 5, 0));

        }
    }
}