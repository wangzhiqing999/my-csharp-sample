using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W0300_WCF_Ajax.Map
{
    public partial class Test_AliyunMap : System.Web.UI.Page
    {

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal lat;


        /// <summary>
        /// 经度
        /// </summary>
        public decimal lon;






        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // 首次进入， 使用默认值查询一次.
                DoMapQuery();
            }
        }


        /// <summary>
        /// 查询.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            DoMapQuery();
        }



        /// <summary>
        /// 执行地图查询.
        /// </summary>
        private void DoMapQuery()
        {
            AliyunMapServuce service = new AliyunMapServuce();
            AliyunGeocodingResult result = service.Geocoding(this.txtAddress.Text);

            this.lon = result.lon;
            this.lat = result.lat;
        }

    }
}