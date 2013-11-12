using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRule.EF
{
    /// <summary>
    /// 部门.
    /// </summary>
    public partial class MR_DEPT
    {

        /// <summary>
        /// 递归 获取所有的 下属部门列表.
        /// </summary>
        /// <returns></returns>
        public List<MR_DEPT> GetAllSubMrDeptList()
        {
            // 预期结果.
            List<MR_DEPT> resultList = new List<MR_DEPT>();

            // 遍历所有的 直属子部门.
            foreach (MR_DEPT subDept in this.MR_DEPT_SUB)
            {
                // 将 直属 子部门加入 结果列表.
                resultList.Add(subDept);

                // 递归， 将 直属 子部门的  下属子部门 加入 结果列表.
                resultList.AddRange (subDept.GetAllSubMrDeptList());
            }

            // 返回.
            return resultList;
        }


    }
}
