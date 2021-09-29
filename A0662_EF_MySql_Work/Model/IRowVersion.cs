using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A0662_EF_MySql_Work.Model
{

    public interface IRowVersion
    {
        /// <summary>
        /// 并发控制字段.
        /// </summary>
        byte[] RowVersion { get; set; }
    }


}
