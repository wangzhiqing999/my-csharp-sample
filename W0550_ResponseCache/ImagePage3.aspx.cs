using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W0550_ResponseCache
{
    public partial class ImagePage3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 设置 缓存.
            Context.Response.Cache.SetExpires(DateTime.Now.AddMinutes(5));
            Context.Response.Cache.SetCacheability(HttpCacheability.Public);
            Context.Response.Cache.SetValidUntilExpires(false);
        }
    }
}