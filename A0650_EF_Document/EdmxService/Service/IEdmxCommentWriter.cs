using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EdmxService.Model;


namespace EdmxService.Service
{
    interface IEdmxCommentWriter
    {

        /// <summary>
        /// 更新 .Edmx 文件中的备注信息.
        /// </summary>
        /// <param name="edmxFileName"></param>
        /// <param name="tableInfoList"></param>
        void EdmxCommentWriter(string edmxFileName, List<TableOrViewInfo> tableInfoList);

    }
}
