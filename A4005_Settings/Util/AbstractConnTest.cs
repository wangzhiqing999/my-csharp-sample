using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;


namespace A4005_Settings.Util
{

    abstract class AbstractConnTest
    {

        /// <summary>
        /// 取得 数据库连接.
        /// </summary>
        /// <returns></returns>
        protected abstract DbConnection GetConnection(string connString);



        public string ResultMessage { set; get; }




        /// <summary>
        /// 测试连接是否有效.
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public bool TestConnect(string connString)
        {
            try {
                using(DbConnection conn = GetConnection(connString)) {

                    conn.Open();

                    System.Threading.Thread.Sleep(1000);

                    conn.Close();

                    return true;
                }
            } catch ( Exception ex) {
                ResultMessage = ex.Message;
                return false;
            }

        }


    }

}
