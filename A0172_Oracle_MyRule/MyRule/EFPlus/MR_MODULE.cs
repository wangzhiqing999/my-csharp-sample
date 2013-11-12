using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRule.EF
{
    /// <summary>
    /// 模块.
    /// </summary>
    public partial class MR_MODULE
    {

        /// <summary>
        /// 递归 获取所有的 下属模块列表.
        /// </summary>
        /// <returns></returns>
        public List<MR_MODULE> GetAllSubMrModuleList()
        {
            // 预期结果.
            List<MR_MODULE> resultList = new List<MR_MODULE>();

            // 遍历所有的 直属子模块.
            foreach (MR_MODULE subDept in this.MR_MODULE_SUB)
            {
                // 将 直属 子模块加入 结果列表.
                resultList.Add(subDept);

                // 递归， 将 直属 子模块的  下属子模块 加入 结果列表.
                resultList.AddRange(subDept.GetAllSubMrModuleList());
            }

            // 返回.
            return resultList;
        }


    }
}
