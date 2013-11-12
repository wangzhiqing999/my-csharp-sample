using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using EdmxService.Model;



namespace EdmxService.Service
{
    interface IDatabaseInfoReader
    {


        /// <summary>
        /// 读取 数据库的 表 / 字段的备注信息.
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        List<TableOrViewInfo> ReadAllTableAndViewInfo(string connString);

    }
}
