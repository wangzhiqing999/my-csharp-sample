using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Threading;

namespace W0550_ResponseCache
{
    public partial class LongTimePage2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // 模拟长时间的数据读取/加载.
            Thread.Sleep(5000);


            // 设置 缓存.
            Context.Response.Cache.SetExpires(DateTime.Now.AddMinutes(5));
            Context.Response.Cache.SetCacheability(HttpCacheability.Public);
            Context.Response.Cache.SetValidUntilExpires(false);




        }
    }
}